using System;
using System.Collections;
using System.Collections.Generic;
using Jewelry.Database.Data;

namespace Jewelry.Database.JewellryRepository
{
    public class JewellryRepository:IJewellryRepository
    {
        private IList<Jewellry> jewellries;

        #region Contructors
        public JewellryRepository():this(5) { }
        public JewellryRepository(int count)
        {
            SetRandomJewellry(count);
        }
        #endregion

        public IEnumerable<Jewellry> GetJewellries()
        {
            return this.jewellries;
        }

        #region Private methods
        private void SetRandomJewellry(int count)
        {
            Random rnd = new Random();
            this.jewellries = new List<Jewellry>();
            for (int i = 0; i < count; i++)
            {
                string[] shapes = GetAllShapes();
                string shape = shapes[rnd.Next(0, shapes.Length - 1)];
                string[] metals = GetAllMetals();
                string metal = metals[rnd.Next(0, metals.Length - 1)];
                string[] brands = GetAllBrands();
                string brand = brands[rnd.Next(0, brands.Length - 1)];
                jewellries.Add(new Jewellry(shape, metal, brand, rnd.Next(1, 500), Currency.Dollar));
            }
        }
       
        private string[] GetAllShapes()
        {
            return new string[] { "ring", "bracelet", "necklace", "earrings", "clock" };
        }
        private string[] GetAllMetals()
        {
            return new string[] { "silver", "gold" };
        }
        private string[] GetAllBrands()
        {
            return new string[] { "Sokolov", "Ray", "Parker", "Atoll" };
        }
        #endregion
    }
}
