// <copyright file="JewelryController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Web.Controllers
{
    #region Usings 
    using System.Collections.Generic;
    using Jewelry.Business.Data;
    using Jewelry.Business.JewelryService;
    using Microsoft.AspNetCore.Mvc;
    #endregion

    /// <summary>
    /// Jewelry controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class JewelryController : Controller
    {
        /// <summary>
        /// The jewelry service
        /// </summary>
        private readonly IJewelryService jewelryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="JewelryController"/> class.
        /// </summary>
        /// <param name="jewelryService">The jewelry service.</param>
        public JewelryController(IJewelryService jewelryService)
        {
            this.jewelryService = jewelryService;
        }

        /// <summary>
        /// Indexes the specified jewelry.
        /// </summary>
        /// <param name="jewelry">The jewelry.</param>
        /// <param name="currency">The currency.</param>
        /// <returns>Main jewelry view</returns>
        public IActionResult Index(Business.Data.Jewelry jewelry, Currency currency)
        {
            jewelry = new Jewelry("ring", "gold", "Ray", 50, Currency.Dollar);
            jewelry.Price = this.jewelryService.ConvertPriceCurrency(jewelry.Price, currency);
            return this.View(jewelry);
        }

        /// <summary>
        /// Lists the specified property name.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>list of sorted jewelries</returns>
        public IActionResult List(string propertyName)
        {
            IEnumerable<Jewelry> sortedListOfJewelries = this.jewelryService.GetSortedJewelriesByPropertyName(propertyName);
            return this.View(sortedListOfJewelries);
        }

        /// <summary>
        /// Filters the specified property name.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="values">The values.</param>
        /// <returns>list of filtered jewelries</returns>
        public IActionResult Filter(string propertyName, string[] values)
        {
            IEnumerable<Jewelry> filteredJewelries = this.jewelryService.GetFilteredJewelries(propertyName, values);
            return this.View(filteredJewelries);
        }
    }
}