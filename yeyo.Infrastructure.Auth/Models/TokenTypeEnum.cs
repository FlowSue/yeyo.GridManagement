using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yeyo.Infrastructure.Auth.Models
{
    internal enum TokenTypeEnum
    {
        /// <summary>
        /// 网页终端
        /// </summary>
        Web,
        /// <summary>
        /// 移动终端
        /// </summary>
        App,
        /// <summary>
        /// 小程序终端
        /// </summary>
        MiniProgram,
        /// <summary>
        /// 其他类型终端
        /// </summary>
        Other,
    }
}
