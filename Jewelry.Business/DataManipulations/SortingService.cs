// <copyright file="SortingService.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>

namespace Jewelry.Business.DataManipulations
{
    #region Usings
    using System.Collections.Generic;
    using System.Linq;
    using Jewelry.Business.Data;
    #endregion

    /// <summary>
    /// Sorting jewelries class
    /// </summary>
    public static class SortingService
    {
        /// <summary>
        /// Sorts the name of the by property.
        /// </summary>
        /// <param name="jewelries">The jewelries.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Enumerable of sorted jewelries</returns>
        public static IEnumerable<Data.Jewelry> SortByPropertyName(IEnumerable<Data.Jewelry> jewelries, string propertyName)
        {
            if (propertyName == null)
            {
                return jewelries;
            }

            if (propertyName != "Price")
            {
                return jewelries.OrderByPropertyName(propertyName);
            }
            jewelries = jewelries.OrderByDescending(x => x.Price.Value);
            return jewelries;
        }
    }
}
