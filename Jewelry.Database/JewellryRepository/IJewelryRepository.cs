// <copyright file="IJewelryRepository.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Database.JewelryRepository
{
    #region Usings
    using System.Collections.Generic;

    using Jewelry.Database.Data;
    #endregion

    /// <summary>
    /// Interface of jewelry repository
    /// </summary>
    public interface IJewelryRepository
    {
        /// <summary>
        /// Gets the jewelries.
        /// </summary>
        /// <returns>Enumeration of jewelries</returns>
        IEnumerable<Jewelry> GetJewelries();
    }
}
