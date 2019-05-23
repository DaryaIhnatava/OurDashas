using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Jewelry.Web.Middlewares
{
    public class LocalizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration configuration;

        public LocalizationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this._next = next;
            this.configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var lang = context.Request.Cookies["lang"];
            if (lang == null)
            {
                context.Response.Cookies.Append("lang", configuration.GetSection("Culture").Value);
                lang = configuration.GetSection("Culture").Value;
            }
            try
            {
                CultureInfo.CurrentCulture = new CultureInfo(lang);
                CultureInfo.CurrentUICulture = new CultureInfo(lang);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            await _next.Invoke(context);
        }
    }
}
