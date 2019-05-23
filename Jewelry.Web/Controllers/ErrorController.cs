// <copyright file="ErrorController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Web.Controllers
{
    #region Usings
    using System;

    using Jewelry.Web.Models;

    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    #endregion

    /// <summary>
    /// Error controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class ErrorController : Controller
    {
        /// <summary>
        /// StatusCode method
        /// </summary>
        /// <returns>view with status code page</returns>
        public IActionResult StatusCode()
        {
            var exceptionHandlerPathFeature =
                HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var path = exceptionHandlerPathFeature?.Path;
            var error = exceptionHandlerPathFeature?.Error;
            var code = HttpContext.Response?.StatusCode;
            if (code != null)
            {
                switch (code)
                {
                    case 500: return this.RedirectToAction("StatusCode500");
                    case 403: return this.RedirectToAction("StatusCode404");
                        default: return this.RedirectToAction("OopsPage");
                }
            }

            return this.View();
        }

        /// <summary>
        /// Statuses the code404.
        /// </summary>
        /// <returns>404 error page</returns>
        public IActionResult StatusCode404()
        {
            return this.View();
        }

        /// <summary>
        /// Statuses the code500.
        /// </summary>
        /// <returns>500 error page</returns>
        public IActionResult StatusCode500()
        {
            return this.View();
        }

        /// <summary>
        /// Statuses the code403.
        /// </summary>
        /// <returns>403 error page</returns>
        public IActionResult StatusCode403()
        {
            return this.View();
        }

        /// <summary>
        /// OopsPage
        /// </summary>
        /// <returns>View page</returns>
        public IActionResult OopsPage()
        {
            return this.View();
        }

        public IActionResult ForDeveloper()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionHandler?.Error != null)
            {
                var exceptionModel = this.ReturnViewModel(exceptionHandler?.Error, HttpContext);
                return this.View(exceptionModel);
            }

            return this.Redirect("/Jewelry/Index");
        }

        /// <summary>
        /// ReturnViewModel method
        /// </summary>
        /// <param name="exception">exception</param>
        /// <param name="context">context</param>
        /// <returns>Error view model</returns>
        private ErrorViewModel ReturnViewModel(Exception exception, HttpContext context)
        {
            return new ErrorViewModel()
            {
                Message = exception.Message,
                InnerException = exception.InnerException,
                Source = exception.Source,
                StatusCode = context.Response.StatusCode,
                HelpLink = exception.HelpLink,
                StackTrace = exception.StackTrace
            };
        }
    }
}