// <copyright file="JewelryService.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>

using Jewelry.Business.CacheService;

namespace Jewelry.Business.JewelryService
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Jewelry.Business.Data;
    using Jewelry.Business.FilterService;
    using Jewelry.Database.JewelryRepository;
    using Microsoft.Extensions.Configuration;
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

        private readonly ICacheService cacheService;

        private readonly IConfiguration configuration;

        private readonly CacheSettings cacheSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="JewelryService"/> class.
        /// </summary>
        /// <param name="jewelryRepository">The Jewelry repository.</param>
        public JewelryService(IJewelryRepository jewelryRepository, ICacheService cacheService, IConfiguration configuration)
        {
            this.jewelryRepository = jewelryRepository;
            this.cacheService = cacheService;
            this.configuration = configuration;
            cacheSettings = new CacheSettings();
            configuration.GetSection("Cache").Bind(cacheSettings);
        }

        /// <summary>
        /// Gets the jewelries.
        /// </summary>
        /// <returns>All jewelries</returns>
        public IEnumerable<Business.Data.Jewelry> GetJewelries()
        {
            if (cacheSettings.IsEnable)
            {
                var jewelriesFromCache = cacheService.GetFromCache();
                if (jewelriesFromCache!=null && jewelriesFromCache.Any())
                {
                    return jewelriesFromCache;
                }
            }
            var jewelries = GetJewelriesFromRepository();
            if (cacheSettings.IsEnable)
            {
                cacheService.AddToCache(jewelries);
            }
            return jewelries;
        }
        /// <summary>
        /// Gets the jewelries from repository.
        /// </summary>
        /// <returns>IEnumerable of Jewelries</returns>
        public IEnumerable<Business.Data.Jewelry> GetJewelriesFromRepository()
        {
            var jewelries = this.jewelryRepository.GetJewelries();
            foreach (var jewelry in jewelries)
            {
                yield return new Business.Data.Jewelry(jewelry.Id,jewelry.Shape, jewelry.Metal, jewelry.Brand, jewelry.Price.Value, (Currency)jewelry.Price.Currency);
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
            if (propertyName == null)
            {
                return jewelries;
            }

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
        /// Convert Price Currency
        /// </summary>
        /// <param name="jewelryPrice">jewelry price</param>
        /// <param name="currency">currency of jewelry</param>
        /// <returns>New jewelry price of jewelry</returns>
        public Price ConvertPriceCurrency(Price jewelryPrice, Currency currency)
        {
            if (jewelryPrice == null)
            {
                throw new ArgumentException();
            }

            if (jewelryPrice.Currency == currency)
            {
                return jewelryPrice;
            }

            CurrencyService.CurrencyConverter.Convert(ref jewelryPrice, currency);
            return jewelryPrice;
        }
    }
}