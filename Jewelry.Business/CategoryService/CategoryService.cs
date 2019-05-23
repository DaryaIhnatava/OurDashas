// <copyright file="CategoryService.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Business.CategoryService
{
    using System;
    #region Usings
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Jewelry.Business.Data;
    using Jewelry.Business.i18n;
    using Jewelry.Business.JewelryService;
    #endregion

    /// <summary>
    /// Category service
    /// </summary>
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// The jewelry service
        /// </summary>
        private readonly IJewelryService jewelryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// </summary>
        /// <param name="jewelryService">The jewelry service.</param>
        public CategoryService(IJewelryService jewelryService)
        {
            this.jewelryService = jewelryService;
        }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns>Enumerable of categories</returns>
        public IEnumerable<Category> GetCategories()
        {
            IEnumerable<Data.Jewelry> jewelries = this.jewelryService.GetJewelries();
            List<Category> categories = new List<Category>();

            foreach (var property in typeof(Data.Jewelry).GetProperties().Where(q => q.Name != "Price" && q.Name != "Id"))
            {
                Type myType = typeof(Resource);
                PropertyInfo[] properties = myType.GetProperties(
                       BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
                var t = properties.Where(x => x.Name == property.Name).FirstOrDefault()?.GetValue(myType, null).ToString();
                categories.Add(new Category()
                {
                    PropertyName = properties.Where(x => x.Name == property.Name).FirstOrDefault()?.GetValue(myType, null).ToString(),
                    PropertyValues = new List<Value>()
                });
                var values = jewelries.Select(j => property.GetValue(j).ToString()).Distinct().ToList();
                foreach (var item in values)
                {
                    categories[categories.Count - 1].PropertyValues.Add(
                        new Value()
                        {
                            PropertyValue = item,
                            Checked = false
                        });
                }
            }

            categories.Add(
                    new Category()
                    {
                        PropertyName = Resource.Price,
                        PropertyValues = new List<Value>()
                        {
                            new Value()
                            {
                                PropertyValue = jewelries.Min(w => w.Price.Value).ToString(),
                                Checked = false
                            },

                            new Value()
                            {
                                PropertyValue = jewelries.Max(w => w.Price.Value).ToString(),
                                Checked = false
                            }
                        }
                    });

            return categories;
        }
    }
}
