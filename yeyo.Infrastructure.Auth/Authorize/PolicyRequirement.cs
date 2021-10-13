using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace yeyo.Infrastructure.Auth.Authorize
{
    /// <summary>
    /// 授权策略
    /// </summary>
    public class PolicyRequirement : IAuthorizationRequirement
    {
        public PolicyRequirement(bool isNeedAuthorized = true)
        {
            this.IsNeedAuthorized = isNeedAuthorized;
        }

        public PolicyRequirement(string role, bool isNeedAuthorized = true)
        {
            this.SetRequireRoles(role.Split(','));
            this.IsNeedAuthorized = isNeedAuthorized;
        }

        internal bool IsNeedAuthorized { get; set; }

        private string[] _requireRoles;

        public IEnumerable<string> GetRequireRoles()
        {
            return _requireRoles;
        }

        private void SetRequireRoles(string[] value)
        {
            _requireRoles = value;
        }
    }
}
