// <copyright file="ErrorController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Web.Controllers
{
    #region Usings
    using Microsoft.AspNetCore.Mvc;
    #endregion

    /// <summary>
    /// Error controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class ErrorController : Controller
    {
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
    }
}