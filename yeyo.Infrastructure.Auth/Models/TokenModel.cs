using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yeyo.Infrastructure.Auth.Models
{
    internal class TokenModel
    {
        /// <summary>
        /// 登录用户Id
        /// </summary>
        public string Uid { get; set; }
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 身份
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Project { get; set; }
        /// <summary>
        /// 系统标识
        /// </summary>
        public string SystemId { get; set; }
        /// <summary>
        /// 令牌类型（终端类型）
        /// </summary>
        public TokenTypeEnum TokenType { get; set; }
    }
}
