// <copyright file="JewelriesViewModel.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Web.Models
{
    #region Usings
    using System.Collections.Generic;

    using Jewelry.Business.Data;
    #endregion

    /// <summary>
    /// Model for UI
    /// </summary>
    public class JewelriesViewModel
    {
        /// <summary>
        /// Gets Jewelries
        /// </summary>
        public IEnumerable<Jewelry> Jewelries { get; set; }

        /// <summary>
        /// Gets categories of jewelry
        /// </summary>
        public CategoryWithPropertiesViewModel categoryWithPropertiesViewModel { get; set; }
    }
}
