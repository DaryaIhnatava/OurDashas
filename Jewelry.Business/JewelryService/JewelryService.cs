// <copyright file="JewelryService.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Business.JewelryService
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Jewelry.Business.Data;
    using Jewelry.Business.FilterService;
    using Jewelry.Database.JewelryRepository;
    #endregion

    /// <summary>
    /// Jewelry Service class
    /// </summary>
    public class JewelryService : IJewelryService
    {
        /// <summary>
        /// The jewelry repository
        /// </summary>
        private readonly IJewelryRepository jewelryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="JewelryService"/> class.
        /// </summary>
        /// <param name="jewelryRepository">The Jewelry repository.</param>
        public JewelryService(IJewelryRepository jewelryRepository)
        {
            this.jewelryRepository = jewelryRepository;
        }

        /// <summary>
        /// Gets the jewelries.
        /// </summary>
        /// <returns>All jewelries</returns>
        public IEnumerable<Data.Jewelry> GetJewelries()
        {
            var jewelries = this.jewelryRepository.GetJewelries();
            foreach (var jewelry in jewelries)
            {
                yield return new Business.Data.Jewelry(jewelry.Shape, jewelry.Metal, jewelry.Brand, jewelry.Price.Value, (Currency)jewelry.Price.Currency);
            }
        }

        /// <summary>
        /// Gets the sorted jewelries.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Sorted jewelries</returns>
        public IEnumerable<Data.Jewelry> GetSortedJewelriesByPropertyName(string propertyName)
        {
            var jewelries = this.GetJewelries();
            var sortedJewelries = jewelries.OrderByPropertyName(propertyName);
            return sortedJewelries;
        }

        /// <summary>
        /// Gets the filtered jewelries.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="values">The values.</param>
        /// <returns>Filtered jewelries</returns>
        public IEnumerable<Data.Jewelry> GetFilteredJewelries(string propertyName, params string[] values)
        {
            var jewelries = this.GetJewelries();
            if (propertyName == null || values == null || values.Length == 0)
            {
                return jewelries;
            }

            return Filter<Data.Jewelry>.FilterByExpression(jewelries.AsQueryable(), propertyName, values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jewelryPrice"></param>
        /// <param name="currency"></param>
        /// <returns>New jewelry price</returns>
        public Price ConvertPriceCurrency(Price jewelryPrice, Currency currency)
        {
            if (jewelryPrice.Currency == currency)
            {
                return jewelryPrice;
            }

            CurrencyService.CurrencyConverter.Convert(ref jewelryPrice, currency);
            return jewelryPrice;
        }
    }
}