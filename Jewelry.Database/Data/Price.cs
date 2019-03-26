// <copyright file="Price.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Database.Data
{
    /// <summary>
    /// Currency enumeration
    /// </summary>
    public enum Currency
    {
        /// <summary>
        /// The dollar
        /// </summary>
        Dollar,

        /// <summary>
        /// The ruble
        /// </summary>
        Ruble,

        /// <summary>
        /// The euro
        /// </summary>
        Euro
    }

    /// <summary>
    /// Price class
    /// </summary>
    public class Price
    {
        /// <summary>
        /// The value
        /// </summary>
        private double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Price"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="currency">The currency.</param>
        public Price(double value, Currency currency)
        {
            this.Value = value;
            this.Currency = currency;
        }
        
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public double Value
        {
            get => this.value;
            set
            {
                if (value > 0)
                {
                    this.value = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public Currency Currency { get; set; }
    }
}
