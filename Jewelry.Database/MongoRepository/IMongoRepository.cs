using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jewelry.Database.MongoRepository
{
    /// <summary>
    /// Mongo repository interface
    /// </summary>
    public interface IMongoRepository
    {
        /// <summary>
        /// Inserts the specified jewelry.
        /// </summary>
        /// <param name="jewelry">The jewelry.</param>
        void Insert(Data.Jewelry jewelry);

        /// <summary>
        /// Gets the jewelries.
        /// </summary>
        /// <param name="minPrice">The minimum price.</param>
        /// <param name="maxPrice">The maximum price.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Task<IEnumerable<Data.Jewelry>> GetJewelries(int? minPrice, int? maxPrice, string name);

        /// <summary>
        /// Gets the jewelries.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Data.Jewelry> GetJewelriesAsync();

        /// <summary>
        /// Gets the jewelry.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Task<Data.Jewelry> GetJewelry(string Id);

        /// <summary>
        /// Updates the specified jewelry.
        /// </summary>
        /// <param name="jewelry">The jewelry.</param>
        /// <returns></returns>
        Task Update(Data.Jewelry jewelry);

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Task Remove(string Id);
    }
}
