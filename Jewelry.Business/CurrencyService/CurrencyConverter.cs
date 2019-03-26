// <copyright file="CurrencyConverter.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Business.CurrencyService
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using Jewelry.Business.Data;
    #endregion

    /// <summary>
    /// Currency converter class
    /// </summary>
    public static class CurrencyConverter
    {
        /// <summary>
        /// Dictionary with exchange rates for all used currencies
        /// </summary>
        private static readonly Dictionary<Tuple<Currency, Currency>, double> CurrencyExchangeRates;

        /// <summary>
        /// Constructor of currency converter with initializing of static dictionary with currency rates
        /// </summary>
        static CurrencyConverter()
        {
            CurrencyExchangeRates = new Dictionary<Tuple<Currency, Currency>, double>
            {
                {
                    new Tuple<Currency, Currency>(Currency.Dollar, Currency.Euro), 0.89
                },
                {
                    new Tuple<Currency, Currency>(Currency.Dollar, Currency.Ruble), 65.78
                },
                {
                    new Tuple<Currency, Currency>(Currency.Euro, Currency.Dollar), 1.13
                },
                {
                    new Tuple<Currency, Currency>(Currency.Euro, Currency.Ruble), 74.06
                },
                {
                    new Tuple<Currency, Currency>(Currency.Ruble, Currency.Euro), 0.013
                },
                {
                    new Tuple<Currency, Currency>(Currency.Ruble, Currency.Dollar), 0.015
                }
            };
        }

        /// <summary>
        /// Method that converts currency into new one
        /// </summary>
        /// <param name="price">existing price</param>
        /// <param name="newCurrency">expecting currency</param>
        public static void Convert(Price price, Currency newCurrency)
        {
            double? exchangeRate = GetExchangeRate(price.Currency, newCurrency);
            if (exchangeRate == null)
            {
                throw new Errors.ExchangeRateNullException("No exchange rate found for current currencies");
            }

            double newPrice = (double)exchangeRate * price.Value;
            price = new Price(newPrice, newCurrency);
        }

        /// <summary>
        /// Private method for searching correct exchange rate
        /// </summary>
        /// <param name="currencyToConvert">currency for converting</param>
        /// <param name="expectedCurrency">expected currency</param>
        /// <returns>exchange rate</returns>
        private static double? GetExchangeRate(Currency currencyToConvert, Currency expectedCurrency)
        {
            if (CurrencyExchangeRates.TryGetValue(new System.Tuple<Currency, Currency>(currencyToConvert, expectedCurrency), out var value))
            {
                return value;
            }

            return null;
        }
    }
}
