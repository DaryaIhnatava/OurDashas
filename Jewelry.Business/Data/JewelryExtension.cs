// <copyright file="JewelryExtension.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Business.Data
{
    #region Usings
    using System.Collections.Generic;
    using System.Linq;
    #endregion

    /// <summary>
    ///  Jewelry Extension
    /// </summary>
    public static class JewelryExtension
    {
        /// <summary>
        /// Orders the name of the by property.
        /// </summary>
        /// <param name="jewelries">The jewelries.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Ordered jewelries</returns>
        public static IEnumerable<Jewelry> OrderByPropertyName(this IEnumerable<Jewelry> jewelries, string propertyName)
        {
            var property = typeof(Jewelry).GetProperty(propertyName);
            return jewelries.OrderBy(x => property.GetValue(x));
        }
    }
}
