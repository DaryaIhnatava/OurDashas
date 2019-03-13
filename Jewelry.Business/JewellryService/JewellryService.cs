namespace Jewelry.Business.JewellryService
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Jewelry.Business.CurrencyService;
    using Jewelry.Business.Data;
    using Jewelry.Business.FilterService;
    using Jewelry.Database.JewellryRepository;
    #endregion


    public class JewellryService : IJewellryService
    {
        /// <summary>
        /// The jewellry repository
        /// </summary>
        private readonly IJewellryRepository jewellryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="JewellryService"/> class.
        /// </summary>
        /// <param name="jewellryRepository">The jewellry repository.</param>
        public JewellryService(IJewellryRepository jewellryRepository)
        {
            this.jewellryRepository = jewellryRepository;
        }

        /// <summary>
        /// Gets the jewellries.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Jewellry> GetJewellries()
        {
            var jewellries = jewellryRepository.GetJewellries();
            foreach (var jewellry in jewellries)
            {
                yield return new Business.Data.Jewellry(jewellry.Shape,
                                                        jewellry.Metal,
                                                        jewellry.Brand,
                                                        jewellry.Price.Value,
                                                        (Currency)jewellry.Price.Currency);
            }
        }

        /// <summary>
        /// Gets the sorted jewellries.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public IEnumerable<Jewellry> GetSortedJewellriesByPropertyName(string propertyName)
        {
            var jewellries = this.GetJewellries();
            var sortedJewellries = jewellries.OrderByPropertyName(propertyName);
            return sortedJewellries;
        }

        /// <summary>
        /// Gets the filtered jewellries.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public IEnumerable<Jewellry> GetFilteredJewellries(string propertyName, params string[] values)
        {
            var jewellries = this.GetJewellries();
            if (propertyName == null || values == null || values.Length == 0)
            {
                return jewellries;
            }

            return Filter<Jewellry>.FilterByExpression(jewellries.AsQueryable(), propertyName, values);
        }

        /// <summary>
        /// Converts the price currency.
        /// </summary>
        /// <param name="jewellry">The jewellry.</param>
        /// <param name="currency">The currency.</param>
        /// <exception cref="ArgumentException"></exception>
        public void ConvertPriceCurrency(Jewellry jewellry, Currency currency)
        {
            if (jewellry.Price.Currency == currency)
            {
                return;
            }
            CurrencyConverter.Convert(jewellry.Price, currency);
        }
    }
}
