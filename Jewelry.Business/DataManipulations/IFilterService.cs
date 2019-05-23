// <copyright file="IFilterService" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Business.FilterService
{
    #region Usings
    using System.Collections.Generic;

    using Jewelry.Business.Data;
    #endregion

    /// <summary>
    /// IFilterService interface
    /// </summary>
    public interface IFilterService
    {
        /// <summary>
        /// Get Filtered Jewelries
        /// </summary>
        /// <param name="categories">categories</param>
        /// <param name="jewelries">jewelries</param>
        /// <returns>list of jewelries</returns>
        IEnumerable<Data.Jewelry> GetFilteredJewelries(List<Category> categories, IEnumerable<Data.Jewelry> jewelries);
    }
}
