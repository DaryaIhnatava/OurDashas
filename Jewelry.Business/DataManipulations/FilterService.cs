// <copyright file="FilterService.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Business.FilterService
{
    #region Usings
    using System.Collections.Generic;
    using System.Linq;

    using Jewelry.Business.Data;
    #endregion

    /// <summary>
    /// FilterService class
    /// </summary>
    public class FilterService : IFilterService
    {
        /// <summary>
        /// Get Filtered Jewelries
        /// </summary>
        /// <param name="categories">categories</param>
        /// <param name="jewelries">jewelries</param>
        /// <returns>list of jewelries</returns>
        public IEnumerable<Data.Jewelry> GetFilteredJewelries(List<Category> categories,
            IEnumerable<Data.Jewelry> jewelries)
        {
            foreach (var item in categories)
            {
                string[] values = item.PropertyValues.Where(c => c.Checked == true)
                    ?.Select(j => j.PropertyValue?.ToString())?.ToArray();
                if (values.Length != 0)
                {
                    jewelries = Filter<Data.Jewelry>.FilterByExpression(jewelries.AsQueryable(), item.PropertyName,
                        values);
                }
            }
            var category = categories.Where(q => q.PropertyName == "Price").FirstOrDefault();
            int? min = category?.PropertyValues[0]?.PropertyValue == null
                ? (int?)null
                : int.Parse(category.PropertyValues[0].PropertyValue);
            int? max = category?.PropertyValues[1]?.PropertyValue == null
                ? (int?)null
                : int.Parse(category.PropertyValues[1].PropertyValue);
            if (min == null && max == null)
            {
                return jewelries;
            }

            if (max != null && min != null)
            {
                jewelries = jewelries.Where(j => j.Price.Value >= (int)min);
                jewelries = jewelries.Where(j => j.Price.Value <= (int)max);

            }
            else
            {
                if (min == null)
                {
                    jewelries = jewelries.Where(j => j.Price.Value <= (int)max);
                }
                if (max == null)
                {
                    jewelries = jewelries.Where(j => j.Price.Value >= (int)min);
                }
            }
            return jewelries;
        }
    }
}
