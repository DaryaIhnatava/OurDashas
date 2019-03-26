// <copyright file="Jewelry.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Business.Data
{
    /// <summary>
    /// Jewelry business class
    /// </summary>
    public class Jewelry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Jewelry" /> class
        /// </summary>
        /// <param name="shape">shape of jewelry</param>
        /// <param name="metal">metal of jewelry</param>
        /// <param name="brand">brand of jewelry</param>
        /// <param name="price">price of jewelry</param>
        /// <param name="currency">currency of jewelry</param>
        public Jewelry(string shape, string metal, string brand, double price, Currency currency)
        {
            this.Shape = shape;
            this.Metal = metal;
            this.Brand = brand;
            this.Price = new Price(price, currency);
        }

        /// <summary>
        /// Gets shape of jewelry
        /// </summary>
        public string Shape { get; private set; }

        /// <summary>
        /// Gets metal of jewelry
        /// </summary>
        public string Metal { get; private set; }

        /// <summary>
        /// Gets brand of jewelry
        /// </summary>
        public string Brand { get; private set; }

        /// <summary>
        /// Sets and gets price of jewelry
        /// </summary>
        public Price Price { get; set; }
    }
}
