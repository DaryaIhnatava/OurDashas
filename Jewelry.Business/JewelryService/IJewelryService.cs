// <copyright file="IJewelryService.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Business.JewelryService
{
    #region Usings
    using System.Collections.Generic;
    using Jewelry.Business.Data;
    #endregion 

    /// <summary>
    /// IJewelry interface
    /// </summary>
    public interface IJewelryService
    {
        /// <summary>
        /// Method for getting all jewelries
        /// </summary>
        /// <returns>IEnumerable of jewelries</returns>
        IEnumerable<Data.Jewelry> GetJewelries();

        /// <summary>
        /// Sort all jewelries
        /// </summary>
        /// <param name="propertyName">property name</param>
        /// <returns>IEnumerable of jewelries</returns>
        IEnumerable<Data.Jewelry> GetSortedJewelriesByPropertyName(string propertyName);

        /// <summary>
        /// Gets the filtered jewelries.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="values">The values.</param>
        /// <returns>IEnumerable of Jewelry</returns>
        IEnumerable<Data.Jewelry> GetFilteredJewelries(string propertyName, params string[] values);

        /// <summary>
        /// Convert jewelry price
        /// </summary>
        /// <param name="jewelryPrice">price of jewelry</param>
        /// <param name="currency">currency on jewelry</param>
        void ConvertPriceCurrency(Price jewelryPrice, Currency currency);
    }
}
