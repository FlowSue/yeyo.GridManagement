﻿using System;
using System.Runtime.Serialization;

namespace yeyo.Infrastructure.Treasury.Extensions
{
    /// <summary>
    /// 日 期：2017.03.04
    /// 描 述：异常信息扩展
    /// </summary>
    [Serializable]
    public class ExceptionEx : Exception
    {
        public ExceptionEx()
        {
        }
        /// <summary>
        ///使用异常消息与一个内部异常实例化一个 类的新实例
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="inner">用于封装在DalException内部的异常实例</param>
        public ExceptionEx(string message, Exception inner)
            : base(message, inner) { }
        public ExceptionEx(string message) : base(message)
        {
        }
        protected ExceptionEx(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }
        /// <summary>
        ///向调用层抛出业务逻辑访问层异常
        /// </summary>
        /// <param name="msg"> 自定义异常消息 </param>
        /// <param name="e"> 实际引发异常的异常实例 </param>
        public static ExceptionEx ThrowBusinessException(Exception e, string msg = StringEx.StrEmpty)
        {
            return !string.IsNullOrEmpty(msg) ? new ExceptionEx(msg, e) : new ExceptionEx("业务逻辑层异常，详情请查看日志信息。", e);
        }
        /// <summary>
        /// 向调用层抛出数据服务访问层异常
        /// </summary>
        /// <param name="e"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ExceptionEx ThrowServiceException(Exception e, string msg = StringEx.StrEmpty)
        {
            return !string.IsNullOrEmpty(msg) ? new ExceptionEx(msg, e) : new ExceptionEx("数据服务层异常，详情请查看日志信息。", e);
        }
        /// <summary>
        ///向调用层抛出数据访问层异常
        /// </summary>
        /// <param name="msg"> 自定义异常消息 </param>
        /// <param name="e"> 实际引发异常的异常实例 </param>
        public static ExceptionEx ThrowDataAccessException(Exception e, string msg = StringEx.StrEmpty)
        {
            return !string.IsNullOrEmpty(msg) ? new ExceptionEx(msg, e) : new ExceptionEx("数据访问层异常，详情请查看日志信息。", e);
        }
        /// <summary>
        ///     向调用层抛出组件异常
        /// </summary>
        /// <param name="msg"> 自定义异常消息 </param>
        /// <param name="e"> 实际引发异常的异常实例 </param>
        public static ExceptionEx ThrowComponentException(Exception e, string msg = StringEx.StrEmpty)
        {
            return !string.IsNullOrEmpty(msg) ? new ExceptionEx(msg, e) : new ExceptionEx("组件异常，详情请查看日志信息。", e);
        }
    }
}
