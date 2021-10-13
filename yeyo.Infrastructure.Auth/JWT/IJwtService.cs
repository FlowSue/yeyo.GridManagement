using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yeyo.Infrastructure.Auth.Models;

namespace yeyo.Infrastructure.Auth.JWT
{
    /// <summary>
    /// Jwt服务[Interface]
    /// </summary>
    internal interface IJwtService
    {
        /// <summary>
        /// 颁发JWT字符串
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <returns></returns>
        string IssueJwt(TokenModel tokenModel);

        /// <summary>
        /// 颁发JWT字符串
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="userName"></param>
        /// <param name="realName"></param>
        /// <param name="role"></param>
        /// <param name="systemId"></param>
        /// <param name="project"></param>
        /// <param name="tokenType"></param>
        /// <returns></returns>
        string IssueJwt(string uid, string userName, string realName, string role, string systemId, string project, TokenTypeEnum tokenType = TokenTypeEnum.Web);

        /// <summary>
        /// 解析jwt字符串
        /// </summary>
        /// <param name="jwtStr"></param>
        /// <returns></returns>
        TokenModel SerializeJwt(string jwtStr);
    }
}
