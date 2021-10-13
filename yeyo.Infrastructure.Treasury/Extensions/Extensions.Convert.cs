using System;
using System.Linq;
using System.Text.Json;

namespace yeyo.Infrastructure.Treasury.Extensions
{
    public static partial class Extensions
    {
        #region 数值转换
        /// <summary>
        /// 转换为整型
        /// </summary>
        /// <param name="data">数据</param>
        public static int ToInt(this object data)
        {
            if (data == default)
                return 0;
            var success = int.TryParse(data.ToString(), out var result);
            if (success)
                return result;
            try
            {
                return Convert.ToInt32(ToDouble(data, 0));
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static int ToInt(this bool hr)
        {
            var str = 0;
            if (hr)
            {
                str = 1;
            }

            return str;
        }
        /// <summary>
        /// 转换为可空整型
        /// </summary>
        /// <param name="data">数据</param>
        public static int? ToIntOrNull(this object data)
        {
            if (data == default)
                return default;
            var isValid = int.TryParse(data.ToString(), out var result);
            return isValid ? result : default(int?);
        }
        /// <summary>
        /// 转换为双精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static double ToDouble(this object data)
        {
            if (data == default)
                return 0;
            return double.TryParse(data.ToString(), out var result) ? result : 0;
        }
        /// <summary>
        /// 转换为双精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static double ToDouble(this object data, int digits)
        {
            return Math.Round(ToDouble(data), digits);
        }
        /// <summary>
        /// 转换为可空双精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static double? ToDoubleOrNull(this object data)
        {
            if (data == default)
                return default;
            var isValid = double.TryParse(data.ToString(), out var result);
            return isValid ? result : default(double?);
        }
        /// <summary>
        /// 转换为高精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static decimal ToDecimal(this object data)
        {
            if (data == default)
                return 0;
            return decimal.TryParse(data.ToString(), out var result) ? result : 0;
        }
        /// <summary>
        /// 转换为高精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static decimal ToDecimal(this object data, int digits)
        {
            return Math.Round(ToDecimal(data), digits);
        }
        /// <summary>
        /// 转换为可空高精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static decimal? ToDecimalOrNull(this object data)
        {
            if (data == default)
                return default;
            var isValid = decimal.TryParse(data.ToString(), out var result);
            return isValid ? result : default(decimal?);
        }
        /// <summary>
        /// 转换为可空高精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static decimal? ToDecimalOrNull(this object data, int digits)
        {
            var result = ToDecimalOrNull(data);
            return result == default ? default(decimal?) : Math.Round(result.Value, digits);
        }
        #endregion

        #region 日期转换
        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="data">数据</param>
        public static DateTime ToDate(this object data)
        {
            if (data == default)
                return DateTime.MinValue;
            return DateTime.TryParse(data.ToString(), out var result) ? result : DateTime.MinValue;
        }
        /// <summary>
        /// 转换为可空日期
        /// </summary>
        /// <param name="data">数据</param>
        public static DateTime? ToDateOrNull(this object data)
        {
            if (data == default)
                return default;
            var isValid = DateTime.TryParse(data.ToString(), out var result);
            return isValid ? result : default(DateTime?);
        }

        #endregion

        #region 布尔转换
        /// <summary>
        /// 转换为布尔值
        /// </summary>
        /// <param name="data">数据</param>
        public static bool ToBool(this object data)
        {
            if (data == default)
                return false;
            var value = GetBool(data);
            if (value != default)
                return value.Value;
            return bool.TryParse(data.ToString(), out var result) && result;
        }
        /// <summary>
        /// 获取布尔值
        /// </summary>
        public static bool? GetBool(this object data)
        {
            return (data.ToString()?.Trim().ToLower()) switch
            {
                "0" => false,
                "1" => true,
                "是" => true,
                "否" => false,
                "yes" => true,
                "no" => false,
                _ => default,
            };
        }
        /// <summary>
        /// 转换为可空布尔值
        /// </summary>
        /// <param name="data">数据</param>
        public static bool? ToBoolOrNull(this object data)
        {
            if (data == default)
                return default;
            var value = GetBool(data);
            if (value != default)
                return value.Value;
            var isValid = bool.TryParse(data.ToString(), out var result);
            return isValid ? result : default(bool?);
        }
        #endregion

        #region 字符串转换
        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="data">数据</param>
        public static string ToString(this object data)
        {
            return data == default ? string.Empty : data.ToString()?.Trim();
        }

        public static string ToStr(this double hr)
        {
            var str = hr.ToString("F0");
            return str;
        }
        public static string ToStrF2(this double hr)
        {
            var str = hr.ToString("#0.00");
            return str;
        }
        public static string ToStrF2(this decimal hr)
        {
            var str = hr.ToString("#0.00");
            return str;
        }
        public static string ToStr(this double? number)
        {
            var str = number.GetValueOrDefault().ToString("F0");
            return str;
        }
        public static string ToStrF2(this double? number)
        {
            var str = number.GetValueOrDefault().ToString("#0.00");
            return str;
        }
        public static string GetValueOrDefault(this string g)
        {
            g ??= string.Empty;
            g = g.Trim();
            return g;
        }
        #endregion

        #region 实体转换  
        /// <summary>
        /// 将object对象转换为实体对象
        /// </summary>
        /// <typeparam name="T">实体对象类名</typeparam>
        /// <param name="asObject">object对象</param>
        /// <returns></returns>
        public static T ConvertObject<T>(this object asObject) where T : new()
        {
            //创建实体对象实例
            var t = Activator.CreateInstance<T>();
            if (asObject == null) return t;
            var type = asObject.GetType();
            //遍历实体对象属性
            foreach (var info in typeof(T).GetProperties())
            {
                //取得object对象中此属性的值
                var val = type.GetProperty(info.Name)?.GetValue(asObject);
                if (val == null) continue;
                //非泛型
                object obj;
                if (!info.PropertyType.IsGenericType)
                    obj = Convert.ChangeType(val, info.PropertyType);
                else//泛型Nullable<>
                {
                    var genericTypeDefinition = info.PropertyType.GetGenericTypeDefinition();
                    obj = genericTypeDefinition == typeof(Nullable<>) ? Convert.ChangeType(val, Nullable.GetUnderlyingType(info.PropertyType)) : Convert.ChangeType(val, info.PropertyType);
                }
                info.SetValue(t, obj, null);
            }
            return t;
        }
        /// <summary>
        /// 将object对象转换为实体对象
        /// </summary>
        /// <typeparam name="T">实体对象类名</typeparam>
        /// <param name="asObject">object对象</param>
        /// <returns></returns>
        public static T ConvertObjectByJson<T>(this object asObject) where T : new()
        {
            //将object对象转换为json字符
            var json = JsonSerializer.Serialize(asObject);
            //将json字符转换为实体对象
            var t = JsonSerializer.Deserialize<T>(json);
            return t;
        }
        /// <summary>
        /// 将object尝试转为指定对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T ConvertObjToModel<T>(object data) where T : new()
        {
            if (data == null) return new T();
            // 定义集合    
            var result = new T();
            
            // 获得此模型的公共属性 
            var properties = result.GetType().GetProperties();
            foreach (var pi in properties)
            {
                var tempName = pi.Name;

                // 判断此属性是否有Setter      
                if (!pi.CanWrite) continue;

                try
                {
                    var value = GetPropertyValue(data, tempName);
                    if (value != DBNull.Value)
                    {
                        var tempType = pi.PropertyType;
                        pi.SetValue(result, GetDataByType(value, tempType), null);

                    }
                }
                catch
                {
                    // ignored
                }
            }

            return result;
        }

        /// <summary>
        /// 获取一个类指定的属性值
        /// </summary>
        /// <param name="info">object对象</param>
        /// <param name="field">属性名称</param>
        /// <returns></returns>
        public static object GetPropertyValue(object info, string field)
        {
            if (info == null) return null;
            var t = info.GetType();
            var property = from pi in t.GetProperties() where string.Equals(pi.Name, field, StringComparison.CurrentCultureIgnoreCase) select pi;
            return property.First().GetValue(info, null);
        }

        /// <summary>
        /// 将数据转为制定类型
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="myparams"></param>
        /// <returns></returns>
        public static object GetDataByType(this object data, Type type, params object[] myparams)
        {
            var result = new object();
            try
            {
                if (type == typeof(decimal))
                {
                    result = Convert.ToDecimal(data);
                    if (myparams.Length > 0)
                    {
                        result = Convert.ToDecimal(Math.Round(Convert.ToDecimal(data), Convert.ToInt32(myparams[0])));
                    }
                }
                else if (type == typeof(double))
                {
                    result = myparams.Length > 0 ? Convert.ToDouble(Math.Round(Convert.ToDouble(data), Convert.ToInt32(myparams[0]))) : double.Parse(Convert.ToDecimal(data).ToString("0.00"));
                }
                else if (type == typeof(int))
                {
                    result = Convert.ToInt32(data);
                }
                else if (type == typeof(DateTime))
                {
                    result = Convert.ToDateTime(data);
                }
                else if (type == typeof(Guid))
                {
                    result = new Guid(data.ToString());
                }
                else if (type == typeof(string))
                {
                    result = data.ToString();
                }
            }
            catch
            {
                if (type == typeof(decimal))
                {
                    result = 0;
                }
                else if (type == typeof(double))
                {
                    result = 0;
                }
                else if (type == typeof(int))
                {
                    result = 0;
                }
                else if (type == typeof(DateTime))
                {
                    result = null;
                }
                else if (type == typeof(Guid))
                {
                    result = Guid.Empty;
                }
                else if (type == typeof(string))
                {
                    result = "";
                }
            }
            return result;
        }
        #endregion
    }
}