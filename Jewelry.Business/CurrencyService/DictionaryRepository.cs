namespace Jewelry.Business.CurrencyService
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using Jewelry.Business.Data;
    #endregion

    public static class DictionaryRepository
    {
        /// <summary>
        /// The dictionary
        /// </summary>
        private readonly static Dictionary<Tuple<Currency, Currency>, double> dictionary;

        /// <summary>
        /// Initializes the <see cref="DictionaryRepository"/> class.
        /// </summary>
        static DictionaryRepository()
        {
            dictionary = new Dictionary<Tuple<Currency, Currency>, double>();
            dictionary.Add(new Tuple<Currency, Currency>(Currency.Dollar, Currency.Euro), 0.89);
            dictionary.Add(new Tuple<Currency, Currency>(Currency.Dollar, Currency.Ruble), 65.78);
            dictionary.Add(new Tuple<Currency, Currency>(Currency.Euro, Currency.Dollar), 1.13);
            dictionary.Add(new Tuple<Currency, Currency>(Currency.Euro, Currency.Ruble), 74.06);
            dictionary.Add(new Tuple<Currency, Currency>(Currency.Ruble, Currency.Euro), 0.013);
            dictionary.Add(new Tuple<Currency, Currency>(Currency.Ruble, Currency.Dollar),0.015);
        }

        /// <summary>
        /// Gets the ratio of the dictionary.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<Tuple<Currency, Currency>, double> GetRatioDictionary()
        {
            return dictionary;
        }
    }
}
