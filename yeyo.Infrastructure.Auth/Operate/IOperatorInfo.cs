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
    internal interface IOperatorInfo
    {
        /// <summary>登录人信息</summary>
        /// <value>The authentication base.</value>
        TokenModel TokenModel { get; }

        /// <summary>登录token</summary>
        /// <value>The token.</value>
        string TokenStr { get; }
    }
}
