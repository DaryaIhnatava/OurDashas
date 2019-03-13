namespace Jewelry.Business.CurrencyService
{
    #region Usings
    using System.Collections.Generic;
    using Jewelry.Business.Data;
    #endregion

    public static class ExchangeRate
    {
        /// <summary>
        /// The dictionary
        /// </summary>
        public static readonly Dictionary<System.Tuple<Currency, Currency>, double> dictionary;

        /// <summary>
        /// Initializes the <see cref="ExchangeRate"/> class.
        /// </summary>
        static ExchangeRate()
        {
            dictionary = DictionaryRepository.GetRatioDictionary();
        }

        /// <summary>
        /// Gets the specified what currency.
        /// </summary>
        /// <param name="whatCurrency">The what currency.</param>
        /// <param name="intoCurrency">The into currency.</param>
        /// <returns></returns>
        public static double? Get(Currency whatCurrency, Currency intoCurrency)
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
