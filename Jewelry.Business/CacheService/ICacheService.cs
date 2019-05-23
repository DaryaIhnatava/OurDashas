namespace Jewelry.Business.CacheService
{
    using System.Collections.Generic;

    /// <summary>
    /// ICacheService
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// Adds to cache.
        /// </summary>
        /// <param name="jewelries">The jewelries.</param>
        void AddToCache(IEnumerable<Data.Jewelry> jewelries);
        /// <summary>
        /// Gets from cache.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Data.Jewelry> GetFromCache();
        /// <summary>
        /// Gets from cache by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Data.Jewelry GetFromCacheById(int Id);
        /// <summary>
        /// Adds to cache.
        /// </summary>
        /// <param name="jewelry">The jewelry.</param>
        void AddToCache(Data.Jewelry jewelry);
    }
}
