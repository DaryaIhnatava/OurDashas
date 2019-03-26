// <copyright file="ErrorMiddleware.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Web.ErrorHandle
{
    #region Usings
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    #endregion

    /// <summary>
    /// Error middleware
    /// </summary>
    public class ErrorMiddleware
    {
        /// <summary>
        /// The next RequestDelegate
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public ErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Invokes the asynchronous.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns>Task of invoking</returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await this.next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Handles the exception asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="exception">The exception.</param>
        /// <returns>Task of error exception async</returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "text/html";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            switch (context.Response.StatusCode)
            {
                case (int)HttpStatusCode.InternalServerError:
                    return GetInternalServerErrorResult(context);
                case (int)HttpStatusCode.NotFound:
                    return GetNotFoundErrorResult(context);
            }

            return null;
        }

        /// <summary>
        /// Gets the internal server error result.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task of internal error</returns>
        private static Task GetInternalServerErrorResult(HttpContext context)
        {
            return context.Response.WriteAsync("<h2>Internal Server Error from the custom middleware.</h2>");
        }

        /// <summary>
        /// Gets the not found error result.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task of not found exception</returns>
        private static Task GetNotFoundErrorResult(HttpContext context)
        {
            return context.Response.WriteAsync("<h2>Not found error from the custom middleware.</h2>");
        }
    }
}
