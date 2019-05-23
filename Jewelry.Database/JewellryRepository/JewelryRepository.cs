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
        public JewelryRepository() : this(50)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JewelryRepository"/> class.
        /// </summary>
        /// <param name="count">The count.</param>
        public JewelryRepository(int count)
        {
            this.SetNotRandomJewelries();
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
                this.jewelries.Add(new Data.Jewelry(1,shape, metal, brand, rnd.Next(1, 1000000), Currency.Dollar));
            }
        }

        /// <summary>
        /// Set Not Random Jewelries
        /// </summary>
        private void SetNotRandomJewelries()
        {
            this.jewelries = new List<Data.Jewelry>()
            {
                new Jewelry(1, "Ring", "Silver", "Piaget", 6585495, Currency.Dollar),
                new Jewelry(2, "Bracelet", "Silver", "Cartier", 65854695, Currency.Dollar),
                new Jewelry(3,"Clock", "Iridium", "Sokolov", 65856495, Currency.Dollar),
                new Jewelry(4,"Bead", "Iridium", "Ray", 3165895, Currency.Dollar),
                new Jewelry(5,"Necklace", "Silver", "Sokolov", 1265895, Currency.Dollar),
                new Jewelry(6,"Ring", "Gold", "Harry Winston", 3265895, Currency.Dollar),
                new Jewelry(7,"Ring", "Rhodium", "Sokolov", 2365895, Currency.Dollar),
                new Jewelry(8,"Bead", "Iridium", "Harry Winston", 4365895, Currency.Dollar),
                new Jewelry(9,"Ring", "Platinum", "Piaget", 324658595, Currency.Dollar),
                new Jewelry(10,"Clock", "Silver", "Ray", 3565895, Currency.Dollar),
                new Jewelry(11,"Bracelet", "Titanium", "Cartier", 36523895, Currency.Dollar),
                new Jewelry(12,"Earrings", "Silver", "Piaget", 243655895, Currency.Dollar),
                new Jewelry(13,"Ring", "Silver", "Harry Winston", 23465895, Currency.Dollar),
                new Jewelry(14,"Pier", "Rhodium", "Sokolov", 34265895, Currency.Dollar),
                new Jewelry(15,"Necklace", "Titanium", "Sokolov", 54365895, Currency.Dollar),
                new Jewelry(16,"Ring", "Gold", "Graff", 64658595, Currency.Dollar),
                new Jewelry(17,"Chain", "Platinum", "Sokolov", 65658495, Currency.Dollar),
                new Jewelry(18,"Pendant", "Silver", "Sokolov", 6454895, Currency.Dollar),
                new Jewelry(19,"Chain", "Rhodium", "Ray", 45655895, Currency.Dollar),
                new Jewelry(20, "Bracelet", "Ruthenium", "Chopard", 345655895, Currency.Dollar),
                new Jewelry(21,"Pendant", "Ruthenium", "Van Cleef & Arpels", 65895, Currency.Dollar),
                new Jewelry(22,"Clock", "Gold", "Sokolov", 456554895, Currency.Dollar),
                new Jewelry(23, "Earrings", "Silver", "Chopard", 546455895, Currency.Dollar),
                new Jewelry(24,"Ring", "Silver", "Van Cleef & Arpels", 56583495, Currency.Dollar),
                new Jewelry(25,"Bracelet", "Platinum", "Graff", 4565895, Currency.Dollar),
                new Jewelry(26,"Earrings", "Silver", "Ray", 64558935, Currency.Dollar),
                new Jewelry(27,"Pier", "Rhodium", "Atoll", 63455895, Currency.Dollar),
                new Jewelry(28,"Bead", "Silver", "Sokolov", 65345895, Currency.Dollar),
                new Jewelry(29,"Bracelet", "Platinum", "Buccellati", 345658295, Currency.Dollar),
                new Jewelry(30,"Ring", "Titanium", "Buccellati", 23658955, Currency.Dollar),
                new Jewelry(31,"Bead", "Gold", "Atoll", 324655895, Currency.Dollar)
            };
        }

        /// <summary>
        /// Gets all shapes.
        /// </summary>
        /// <returns>array of shapes</returns>
        private string[] GetAllShapes()
        {
            return new string[] { "Ring", "Bracelet", "Necklace", "Earrings", "Clock", "Chain", "Bead", "Pendant", "Pier" };
        }

        /// <summary>
        /// Gets all metals.
        /// </summary>
        /// <returns>array of metals</returns>
        private string[] GetAllMetals()
        {
            return new string[] { "Silver", "Gold", "Rhodium", "Platinum", "Iridium", "Ruthenium", "Palladium", "Titanium" };
        }

        /// <summary>
        /// Gets all brands.
        /// </summary>
        /// <returns>array of brands</returns>
        private string[] GetAllBrands()
        {
            return new string[] { "Sokolov", "Ray", "Parker", "Atoll", "Harry Winston", "Buccellati", "Van Cleef & Arpels", "Graff", "Tiffany & Co.", "Piaget", "Cartier", "Chopard" };
        }
        #endregion
    }
}
