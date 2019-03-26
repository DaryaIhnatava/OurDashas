// <copyright file="ExceptionHandlerMiddlewareExtension.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Web.ErrorHandle
{
    #region Usings
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Http;
    #endregion

    /// <summary>
    /// Extension method for IApplicationBuilder
    /// </summary>
    public static class ExceptionHandlerMiddlewareExtension
    {
        /// <summary>
        /// Configures the exception handler.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "text/html";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                        await context.Response.WriteAsync("<h2>ERROR!</h2><br>\r\n");
                        await context.Response.WriteAsync("<h4>Status code: " + context.Response.StatusCode + "</h4><br>\r\n");
                        await context.Response.WriteAsync("<a href=\"/\">Home page</a><br>\r\n");
                        await context.Response.WriteAsync("</body></html>\r\n");
                    }
                });
            });
        }
    }
}
