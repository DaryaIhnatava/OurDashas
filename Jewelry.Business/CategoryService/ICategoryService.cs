// <copyright file="ICategoryService.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Business.CategoryService
{
    #region Usings
    using System.Collections.Generic;

    using Jewelry.Business.Data;
    #endregion

    /// <summary>
    /// Interface of category service
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Get categories
        /// </summary>
        /// <returns>enumerable of categories</returns>
        IEnumerable<Category> GetCategories();
    }
}
