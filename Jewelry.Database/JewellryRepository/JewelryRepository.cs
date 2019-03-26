// <copyright file="JewelryRepository.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Database.JewelryRepository
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using Jewelry.Database.Data;
    #endregion

    /// <summary>
    /// Jewelry Repository
    /// </summary>
    /// <seealso cref="Jewelry.Database.JewelryRepository.IJewelryRepository" />
    public class JewelryRepository : IJewelryRepository
    {
        /// <summary>
        /// The jewelries
        /// </summary>
        private IList<Data.Jewelry> jewelries;

        #region Contructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="JewelryRepository"/> class.
        /// </summary>
        public JewelryRepository() : this(5)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JewelryRepository"/> class.
        /// </summary>
        /// <param name="count">The count.</param>
        public JewelryRepository(int count)
        {
            this.SetRandomJewelry(count);
        }
        #endregion

        /// <summary>
        /// Gets the jewelries.
        /// </summary>
        /// <returns>
        /// Enumeration of jewelries
        /// </returns>
        public IEnumerable<Data.Jewelry> GetJewelries()
        {
            return this.jewelries;
        }

        #region Private methods        
        /// <summary>
        /// Sets the random jewelry.
        /// </summary>
        /// <param name="count">The count.</param>
        private void SetRandomJewelry(int count)
        {
            Random rnd = new Random();
            this.jewelries = new List<Data.Jewelry>();
            for (int i = 0; i < count; i++)
            {
                string[] shapes = this.GetAllShapes();
                string shape = shapes[rnd.Next(0, shapes.Length - 1)];
                string[] metals = this.GetAllMetals();
                string metal = metals[rnd.Next(0, metals.Length - 1)];
                string[] brands = this.GetAllBrands();
                string brand = brands[rnd.Next(0, brands.Length - 1)];
                this.jewelries.Add(new Data.Jewelry(shape, metal, brand, rnd.Next(1, 500), Currency.Dollar));
            }
        }

        /// <summary>
        /// Gets all shapes.
        /// </summary>
        /// <returns>array of shapes</returns>
        private string[] GetAllShapes()
        {
            return new string[] { "ring", "bracelet", "necklace", "earrings", "clock" };
        }

        /// <summary>
        /// Gets all metals.
        /// </summary>
        /// <returns>array of metals</returns>
        private string[] GetAllMetals()
        {
            return new string[] { "silver", "gold" };
        }

        /// <summary>
        /// Gets all brands.
        /// </summary>
        /// <returns>array of brands</returns>
        private string[] GetAllBrands()
        {
            return new string[] { "Sokolov", "Ray", "Parker", "Atoll" };
        }
        #endregion
    }
}
