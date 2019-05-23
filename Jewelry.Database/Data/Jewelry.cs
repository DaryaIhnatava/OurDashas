// <copyright file="Jewelry.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Database.Data
{
    /// <summary>
    /// Jewelry class
    /// </summary>
    public class Jewelry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Jewelry"/> class.
        /// </summary>
        /// <param name="shape">The shape.</param>
        /// <param name="metal">The metal.</param>
        /// <param name="brand">The brand.</param>
        /// <param name="price">The price.</param>
        /// <param name="currency">The currency.</param>
        public Jewelry(int Id, string shape, string metal, string brand, double price, Currency currency)
        {
            this.Id = Id;
            this.Shape = shape;
            this.Metal = metal;
            this.Brand = brand;
            this.Price = new Price(price, currency);
        }
        public int Id { get; }
        /// <summary>
        /// Gets the shape.
        /// </summary>
        /// <value>
        /// The shape.
        /// </value>
        public string Shape { get; }

        /// <summary>
        /// Gets the metal.
        /// </summary>
        /// <value>
        /// The metal.
        /// </value>
        public string Metal { get; }

        /// <summary>
        /// Gets the brand.
        /// </summary>
        /// <value>
        /// The brand.
        /// </value>
        public string Brand { get; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public Price Price { get; set; }
    }
}
