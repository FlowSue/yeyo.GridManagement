using System;
using System.Collections.Generic;
using SqlSugar;

namespace yeyo.GridManagement.DomainServices.Repository
{
    public class Repository<T> : SimpleClient<T> where T : class, new()
    {
        protected Repository(ISqlSugarClient context = null) : base(context)//注意这里要有默认值等于null
        {
            if (context != null) return;
            base.Context = new SqlSugarClient(new ConnectionConfig()
            {
                DbType = SqlSugar.DbType.Sqlite,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true,
                //ConnectionString = Config.ConnectionString
            });

            base.Context.Aop.OnLogExecuting = (s, p) =>
            {
                Console.WriteLine(s);
            };
        }

        /// <summary>
        /// 扩展方法，自带方法不能满足的时候可以添加新方法
        /// </summary>
        /// <returns></returns>
        public List<T> CommQuery(string json)
        {
            var t = Context.Utilities.DeserializeObject<T>(json);
            var list = base.Context.Queryable<T>().WhereClass(t).ToList();
            return list;
        }
    }

}
