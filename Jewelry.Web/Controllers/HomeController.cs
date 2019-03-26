// <copyright file="HomeController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Web.Controllers
{
    #region Usings
    using System.Diagnostics;
    using Jewelry.Business.Errors;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    #endregion

    /// <summary>
    /// HomeController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Main home page</returns>
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// IActionResult About
        /// </summary>
        /// <returns>About view</returns>
        public IActionResult About()
        {
            throw new ExchangeRateNullException("No exchange rate found for current currencies");
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
