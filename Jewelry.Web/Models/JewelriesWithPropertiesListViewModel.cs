// <copyright file="JewelriesWithPropertiesListViewModel.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Web.Models
{
    #region Usings
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Jewelries With Properties List View Model
    /// </summary>
    public class JewelriesWithPropertiesListViewModel
    {
        /// <summary>
        /// Gets or sets the Jewelries.
        /// </summary>
        /// <value>
        /// The Jewelries.
        /// </value>
        public IEnumerable<Jewelry.Business.Data.Jewelry> Jewelries { get; set; }

        /// <summary>
        /// Gets or sets the Properties.
        /// </summary>
        /// <value>
        /// The Properties.
        /// </value>
        public IEnumerable<string> Properties { get; set; }
    }
}
