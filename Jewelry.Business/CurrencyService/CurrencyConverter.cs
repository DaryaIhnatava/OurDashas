namespace Jewelry.Business.CurrencyService
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using Jewelry.Business.Data;
    #endregion
    
    public static class CurrencyConverter
    {
        private static readonly Dictionary<Tuple<Currency, Currency>, double> CurrencyExchangeRates;

        static CurrencyConverter()
        {
            CurrencyExchangeRates = new Dictionary<Tuple<Currency, Currency>, double>
            {
                {new Tuple<Currency, Currency>(Currency.Dollar, Currency.Euro), 0.89},
                {new Tuple<Currency, Currency>(Currency.Dollar, Currency.Ruble), 65.78},
                {new Tuple<Currency, Currency>(Currency.Euro, Currency.Dollar), 1.13},
                {new Tuple<Currency, Currency>(Currency.Euro, Currency.Ruble), 74.06},
                {new Tuple<Currency, Currency>(Currency.Ruble, Currency.Euro), 0.013},
                {new Tuple<Currency, Currency>(Currency.Ruble, Currency.Dollar), 0.015}
            };
        }
        public static void Convert(Price price, Currency newCurrency)
        {
            double? exchangeRate = GetExchangeRate(price.Currency, newCurrency);
            if (exchangeRate == null)
            {
                throw new ArgumentException();
            }

            double newPrice = (double)exchangeRate * price.Value;
            price = new Price(newPrice, newCurrency);
        }

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
