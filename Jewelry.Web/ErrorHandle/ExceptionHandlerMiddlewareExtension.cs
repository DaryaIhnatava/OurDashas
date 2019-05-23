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
                        await context.Response.WriteAsync("<h2 style=\"color:red;text-align:center \">ERROR!</h2><br>\r\n");
                        await context.Response.WriteAsync("<table>");
                        await context.Response.WriteAsync("<table>" +
                                                          "<tr>" +
                                                          "<td style=\"color: aqua; font - weight: bold; font-size: 22px\"> HelpLink" +
                                                          "</td>" +
                                                          "<td style =\"color:black; font-size: 18px; width:100px\"> " + contextFeature.Error.HelpLink +
                                                          "</ td ></ tr >" +
                            "<tr>" +
                            "<td style=\"color: aqua; font - weight: bold; font-size: 22px\"> Message" +
                            "</td>" +
                            "<td style =\"color:black; font-size: 18px\"> " + contextFeature.Error.Message +
                            "</ td ></ tr >" +

                           "<tr>" +
                            "<td style=\"color: aqua; font - weight: bold; font-size: 22px\"> Source" +
                            "</td>" +
                            "<td style =\"color:black; font-size: 18px\"> " + contextFeature.Error.Source +
                            "</ td ></ tr >"
                            +
                                                          "<tr>" +
                                                          "<td style=\"color: aqua; font - weight: bold; font-size: 22px\"> Stack trace" +
                                                          "</td>" +
                                                          "<td style =\"color:black; font-size:018px\"> " + contextFeature.Error.StackTrace +
                                                          "</ td ></ tr >"
                                                          +
                                                          "<tr>" +
                                                          "<td style=\"color: aqua; font - weight: bold; font-size: 22px\"> Target Site" +
                                                          "</td>" +
                                                          "<td style =\"color:black; font-size: 18px\"> " + contextFeature.Error.TargetSite +
                                                          "</ td ></ tr >"
                                                          +
                                                          "<tr>" +
                                                          "<td style=\"color: aqua; font - weight: bold; font-size: 22px\"> Inner exception" +
                                                          "</td>" +
                                                          "<td style =\"color:black; font-size: 18px\"> " + contextFeature.Error.InnerException ?? "No inner exception" +
                                                          "</ td ></ tr ></table >"
                                                          );
                    }
                });
            });
        }
    }
}
