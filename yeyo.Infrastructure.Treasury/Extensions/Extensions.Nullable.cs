using System.Collections.Generic;
using System.Linq;

namespace yeyo.Infrastructure.Treasury.Extensions
{
    /// <summary>
    /// 扩展 - 可空类型
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 安全返回值
        /// </summary>
        /// <param name="value">可空值</param>
        public static T SafeValue<T>(this T? value) where T : struct
        {
            return value ?? default;
        }

        public static IEnumerable<T> CheckNull<T>(this IEnumerable<T> list)
        {
            return list ?? new List<T>(0);
        }

        public static TSource FirstOrNew<TSource>(this IEnumerable<TSource> source) where TSource : class, new()
        {
            var tSource = source.FirstOrDefault();
            return tSource ?? new TSource();
        }

        public static TSource FirstOrNew<TSource>(this List<TSource> source) where TSource : class, new()
        {
            var tSource = source.FirstOrDefault();
            return tSource ?? new TSource();
        }
        public static TSource FirstOrNew<TSource>(this IOrderedEnumerable<TSource> source) where TSource : class, new()
        {
            var tSource = source.FirstOrDefault();
            return tSource ?? new TSource();
        }

        public static TSource FirstOrNew<TSource>(this TSource source) where TSource : class, new()
        {
            return source ?? new TSource();
        }
    }
}
