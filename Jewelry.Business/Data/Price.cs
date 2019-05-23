// <copyright file="Price.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>

using System.ComponentModel.DataAnnotations;
using Jewelry.Business.i18n;

namespace Jewelry.Business.Data
{
    #region Usings
    using System;
    #endregion

    /// <summary>
    /// Enumeration currency
    /// </summary>
    public enum Currency
    {
        /// <summary>
        /// Dollar value
        /// </summary>
        Dollar,

        /// <summary>
        /// Ruble value
        /// </summary>
        Ruble,

        /// <summary>
        /// Euro value
        /// </summary>
        Euro,

        /// <summary>
        /// My currency
        /// </summary>
        MyCurrency
    }

    /// <summary>
    /// Price class
    /// </summary>
    public class Price : IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Price" /> class
        /// </summary>
        /// <param name="value">value of price</param>
        /// <param name="currency">value of price currency</param>
        public Price(double value, Currency currency)
        {
            this.Value = value;
            this.Currency = currency;
        }

        /// <summary>
        /// Gets and sets value
        /// </summary>
        [Display(Name = "Price", ResourceType = typeof(Resource))]
        public double Value { get; set; }

        /// <summary>
        /// Gets and sets currency
        /// </summary>
        [Display(Name = "Currency", ResourceType = typeof(Resource))]
        public Currency Currency { get; set; }

        /// <summary>
        /// Method for compare of jewelries
        /// </summary>
        /// <param name="obj">object for compare</param>
        /// <returns> compared prices</returns>
        public int CompareTo(object obj)
        {
            if (obj is Price price)
            {
                return this.Value.CompareTo(price.Value);
            }

            throw new ArgumentException("Parameter is not a Price!");
        }
    }
}
