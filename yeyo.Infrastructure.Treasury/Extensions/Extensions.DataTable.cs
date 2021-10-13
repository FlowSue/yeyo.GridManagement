using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace yeyo.Infrastructure.Treasury.Extensions
{
    public static partial class Extensions
    {
        #region # DataTable转换泛型集合扩展方法 —— static IList<T> ToList<T>(this DataTable...
        /// <summary>
        /// DataTable转换泛型集合扩展方法
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="dataTable">数据表</param>
        /// <returns>泛型集合</returns>
        public static List<T> ToList<T>(this DataTable dataTable)
        {
            //获取类型与属性信息
            var currentType = typeof(T);
            var properties = currentType.GetProperties();

            //获取无参构造函数
            var constructors = currentType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var noParamCtor = constructors.Single(x => x.GetParameters().Length == 0);

            #region # 验证

            if (dataTable == default)
            {
                throw new ArgumentNullException(nameof(dataTable), "数据表不可为null！");
            }

            #endregion

            var collection = new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                var instance = (T)noParamCtor.Invoke(default);

                foreach (var property in properties)
                {
                    if (dataTable.Columns.Contains(property.Name))
                    {
                        var setter = property.GetSetMethod(true);
                        if (setter != default)
                        {
                            var value = row[property.Name] == DBNull.Value ? default : row[property.Name];
                            setter.Invoke(instance, new[] { value });
                        }
                    }

                    var displayName = property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                    if (!dataTable.Columns.Contains(displayName)) continue;
                    {
                        var setter = property.GetSetMethod(true);
                        if (setter == default) continue;
                        {
                            var value = row[displayName] == DBNull.Value ? default : row[displayName];
                            setter.Invoke(instance, new[] { value });
                        }
                    }
                }
                collection.Add(instance);
            }
            return collection;
        }
        #endregion

        #region # 泛型集合转换DataTable扩展方法 —— static DataTable ToDataTable<T>(this IEnumerable...
        /// <summary>
        /// 泛型集合转换DataTable扩展方法
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="enumerable">集合</param>
        /// <returns>DataTable</returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> enumerable)
        {
            #region # 验证参数

            if (enumerable == default)
            {
                throw new ArgumentNullException(nameof(enumerable), "集合不可为null！");
            }

            #endregion

            //获取类型与属性信息
            var currentType = typeof(T);
            var properties = currentType.GetProperties();

            var dataTable = new DataTable();

            //创建列
            foreach (var property in properties)
            {
                dataTable.Columns.Add(new DataColumn(property.Name));
            }

            //创建行
            var array = enumerable.ToArray();
            for (var i = 0; i < array.Length; i++)
            {
                foreach (var property in properties)
                {
                    dataTable.Rows[i][property.Name] = property.GetValue(array[i]);
                }
            }

            return dataTable;
        }
        #endregion

        #region # 泛型集合转换为分割字符串扩展方法 —— static string ToSplicString<T>(this IEnumerable<T>...
        /// <summary>
        /// 泛型集合转换为分割字符串扩展方法
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="enumerable">集合</param>
        /// <returns>分割字符串</returns>
        public static string ToSpliceString<T>(this IEnumerable<T> enumerable)
        {
            var builder = new StringBuilder();
            foreach (var item in enumerable)
            {
                builder.AppendFormat("'{0}'", item);
                builder.Append(',');
            }

            return builder.Length > 0 ? builder.ToString().Substring(0, builder.Length - 1) : string.Empty;
        }
        #endregion
    }
}