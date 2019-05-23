using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Jewelry.Web.Middlewares
{
    public class ThemeMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly IConfiguration configuration;

        public ThemeMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this._next = next;
            this.configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var theme = context.Request.Cookies["theme"];
            if (theme == null)
            {
                context.Response.Cookies.Append("theme", configuration.GetSection("Theme").Value);
                theme = configuration.GetSection("Theme").Value;
            }
            await _next.Invoke(context);
        }
    }
}
