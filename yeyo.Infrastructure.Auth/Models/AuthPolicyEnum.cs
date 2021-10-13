using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yeyo.Infrastructure.Auth.Models
{
    internal enum AuthPolicyEnum
    {
        /// <summary>
        /// 开放接口，不需要授权
        /// </summary>
        Free,
        /// <summary>
        /// 仅对系统管理员开放
        /// </summary>
        RequireRoleOfSystemAdmin
    }
}
