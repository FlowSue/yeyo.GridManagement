using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using yeyo.Infrastructure.Auth.Models;
using yeyo.Infrastructure.Treasury.AutoConfigModel;

namespace yeyo.Infrastructure.Auth.JWT
{
    internal class JwtService : IJwtService
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly JwtOptionConfig _jwtConfig;

        public JwtService(JwtSecurityTokenHandler jwtSecurityTokenHandler, JwtOptionConfig jwtConfig)
        {
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
            _jwtConfig = jwtConfig;
        }
        public string IssueJwt(TokenModel tokenModel)
        {
            var dateTime = DateTime.UtcNow;
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Iss,"yeyo"),//颁发人
                new(JwtRegisteredClaimNames.Sub,tokenModel.UserName),//用户
                new(JwtRegisteredClaimNames.Jti,tokenModel.Uid),//用户Id
                new(JwtClaimTypes.Role, tokenModel.Role),//身份
                new(JwtRegisteredClaimNames.Iat,dateTime.ToUniversalTime().ToString(CultureInfo.InvariantCulture),ClaimValueTypes.Integer64),
                new(ClaimEnum.TokenModel.ToString(),JsonConvert.SerializeObject(tokenModel)),
            };
            var expMin = tokenModel.TokenType switch
            {
                TokenTypeEnum.Web => _jwtConfig.WebExp,
                TokenTypeEnum.App => _jwtConfig.AppExp,
                TokenTypeEnum.MiniProgram => _jwtConfig.MiniProgramExp,
                TokenTypeEnum.Other => _jwtConfig.OtherExp,
                _ => _jwtConfig.OtherExp,
            };
            var expTime = dateTime.AddMinutes(expMin);

            //todo 写入缓存

            //秘钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SecurityKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                notBefore: DateTime.UtcNow,
                audience: tokenModel.TokenType.ToString(),
                issuer: "yeyo",
                claims: claims,
                expires: expTime,//过期时间
                signingCredentials: cred);

            var encodedJwt = _jwtSecurityTokenHandler.WriteToken(jwt);

            return $"{JwtBearerDefaults.AuthenticationScheme} {encodedJwt}";
        }

        public string IssueJwt(string uid, string userName, string realName, string role, string systemId, string project,
            TokenTypeEnum tokenType = TokenTypeEnum.Web)
        {
            return IssueJwt(new TokenModel() { Uid = uid, UserName = userName, RealName = realName, Role = role, Project = project, SystemId = systemId, TokenType = tokenType });
        }

        public TokenModel SerializeJwt(string jwtStr)
        {
            var tm = new TokenModel();
            try
            {
                var jwtToken = _jwtSecurityTokenHandler.ReadJwtToken(jwtStr);
                jwtToken.Payload.TryGetValue("TokenModel", out var tokenModelObj);
                tm = JsonConvert.DeserializeObject<TokenModel>(tokenModelObj?.ToString()!);
            }
            catch (Exception)
            {
                // ignored
            }
            return tm;
        }
    }
}
