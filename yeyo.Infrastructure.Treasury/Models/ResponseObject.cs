using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yeyo.Infrastructure.Treasury.Models
{
    public class ResponseObject
    {
        /// <summary>
        /// 接口响应码
        /// </summary>
        public ResponseCode Code { get; set; }
        /// <summary>
        /// 接口响应消息
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// 接口响应数据
        /// </summary>
        public object Data { get; set; }
    }
    public class ResponseObject<T>
    {
        /// <summary>
        /// 接口响应码
        /// </summary>
        public ResponseCode Code { get; set; }
        /// <summary>
        /// 接口响应消息
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// 接口响应数据
        /// </summary>
        public T Data { get; set; }
    }
}
