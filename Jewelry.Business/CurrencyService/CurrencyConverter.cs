using System;
using System.Collections.Generic;
using Jewelry.Business.Data;

namespace Jewelry.Business.CurrencyService
{
    public static class CurrencyConverter
    {
        private readonly static Dictionary<Tuple<Currency, Currency>, double> dictionary;

        static CurrencyConverter()
        {
            dictionary = new Dictionary<Tuple<Currency, Currency>, double>();
            dictionary.Add(new Tuple<Currency, Currency>(Currency.Dollar, Currency.Euro), 0.89);
            dictionary.Add(new Tuple<Currency, Currency>(Currency.Dollar, Currency.Ruble), 65.78);
            dictionary.Add(new Tuple<Currency, Currency>(Currency.Euro, Currency.Dollar), 1.13);
            dictionary.Add(new Tuple<Currency, Currency>(Currency.Euro, Currency.Ruble), 74.06);
            dictionary.Add(new Tuple<Currency, Currency>(Currency.Ruble, Currency.Euro), 0.013);
            dictionary.Add(new Tuple<Currency, Currency>(Currency.Ruble, Currency.Dollar), 0.015);
        }
        public static void Convert(Jewellry jewellry, Currency newCurrency)
        {
            double? exchangeRate = ExchangeRate.Get(jewellry.Price.Currency, newCurrency);
            if (exchangeRate == null)
            {
                throw new ArgumentException();
            }

            double newPrice = (double)exchangeRate * jewellry.Price.Value;
            jewellry.Price = new Price(newPrice, newCurrency);
        }

        private static double? GetExchangeRate(Currency whatCurrency, Currency intoCurrency)
        {
            double value;
            if (dictionary.TryGetValue(new System.Tuple<Currency, Currency>(whatCurrency, intoCurrency), out value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

    }
}
