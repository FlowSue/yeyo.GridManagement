using System;

namespace yeyo.Infrastructure.Treasury.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNullOrEmpty(this byte? g)
        {
            return g is null or new byte();
        }
        public static bool IsNullOrEmpty(this byte g)
        {
            return g == new byte();
        }
        public static bool IsNullOrEmpty(this double? g)
        {
            return g is null or new double();
        }
        public static bool IsNullOrEmpty(this double g)
        {
            return Math.Abs(g - new double()) < 0;
        }
        public static bool IsNullOrEmpty(this float? g)
        {
            return g is null or new float();
        }
        public static bool IsNullOrEmpty(this float g)
        {
            return Math.Abs(g - new float()) < 0;
        }
        public static bool IsNullOrEmpty(this long? g)
        {
            return g is null or new long();
        }
        public static bool IsNullOrEmpty(this long g)
        {
            return g == new long();
        }
        public static bool IsNullOrEmpty(this short? g)
        {
            return g is null or new short();
        }
        public static bool IsNullOrEmpty(this short g)
        {
            return g == new short();
        }
        public static bool IsNullOrEmpty(this decimal? g)
        {
            return g is null or new decimal();

        }
        public static bool IsNullOrEmpty(this decimal g)
        {
            return g == new decimal();
        }
        public static bool IsNullOrEmpty(this DateTime? g)
        {
            return g == default || g.Value == new DateTime();
        }

        public static bool IsNullOrEmpty(this DateTime g)
        {
            return g == default || g == new DateTime();
        }

        public static bool IsNullOrEmpty(this string g)
        {
            return g == default || string.IsNullOrEmpty(g.Trim());
        }
        public static bool IsNullOrEmpty(this Guid? g)
        {
            return g == default || g.Value == new Guid();
        }
        public static bool IsNullOrEmpty(this Guid g)
        {
            return g == default || g == new Guid();
        }
        public static bool IsNullOrEmpty(this int? g)
        {
            return g is null or 0;
        }
        public static bool IsNullOrEmpty(this int g)
        {
            return g == 0;
        }
        /// <summary>
        /// 检测空值,为default则抛出ArgumentNullException异常
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="parameterName">参数名</param>
        public static void CheckNull(this object obj, string parameterName)
        {
            if (obj == default)
                throw new ArgumentNullException(parameterName);
        }
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this Guid? value)
        {
            return value == default || IsEmpty(value.Value);
        }
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this Guid value)
        {
            return value == Guid.Empty;
        }
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this object value)
        {
            return value == default || string.IsNullOrEmpty(value.ToString());
        }
    }
}