using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using yeyo.Infrastructure.Auth.JWT;
using yeyo.Infrastructure.Auth.Models;
using yeyo.Infrastructure.Treasury.Extensions;

namespace yeyo.Infrastructure.Auth.Operate
{
    internal class OperatorInfo : IOperatorInfo
    {
        private readonly HttpContext _httpContext;

        private readonly IJwtService _jwtService;

        public OperatorInfo(IHttpContextAccessor httpContextAccessor, IJwtService jwtService)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _jwtService = jwtService;
        }

        /// <summary>
        /// 令牌字符串
        /// </summary>
        public string TokenStr => (_httpContext.Request.Headers["Authorization"].ToString().IsEmpty() ? "Bearer " : _httpContext.Request.Headers["Authorization"].ToString()).Substring("Bearer ".Length)?.Trim();

        /// <summary>
        /// 令牌
        /// </summary>
        public TokenModel TokenModel => _jwtService.SerializeJwt(TokenStr);
    }
}
