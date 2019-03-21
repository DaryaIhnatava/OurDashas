// <copyright file="HomeController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>

using Jewelry.Business.MessageService;

namespace Jewelry.Web.Controllers
{
    #region Usings
    using System.Diagnostics;
    using Jewelry.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    #endregion

    /// <summary>
    /// HomeController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// Gets message in Index view
        /// </summary>
        /// <param name="messageService">The message service.</param>
        /// <returns>Index view</returns>
        public IActionResult Index([FromServices]IMessageService messageService)
        {
            this.ViewBag.Message = messageService.GetMessage();
            return this.View();
        }

        /// <summary>
        /// IActionResult About
        /// </summary>
        /// <returns>About view</returns>
        public IActionResult About()
        {
            this.ViewData["Message"] = "Your application description page.";
            return this.View();
        }

        /// <summary>
        /// IActionResult Contact
        /// </summary>
        /// <returns>View of contacts</returns>
        public IActionResult Contact()
        {
            this.ViewData["Message"] = "Your contact page.";
            return this.View();
        }

        /// <summary>
        /// IActionResult Error
        /// </summary>
        /// <returns>View of error</returns>
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
