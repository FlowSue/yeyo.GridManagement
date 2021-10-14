using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace yeyo.Infrastructure.CustomException
{
    internal static class DiExtension
    {
        public static void UseExceptionService(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();//自定义异常处理中间件
        }
    }
}
