namespace Jewelry.Business.CacheService
{

    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Configuration;

    /// <summary>CacheService</summary>
    public class CacheService : ICacheService
    {
        /// <summary>
        /// The cache
        /// </summary>
        private readonly IMemoryCache cache;
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheService"/> class.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="configuration">The configuration.</param>
        public CacheService(IMemoryCache cache, IConfiguration configuration)
        {
            this.cache = cache;
            this.configuration = configuration;
        }

        /// <summary>
        /// Adds to cache.
        /// </summary>
        /// <param name="jewelries">The jewelries.</param>
        public void AddToCache(IEnumerable<Data.Jewelry> jewelries)
        {
            cache.Set("jewelry", jewelries,
                new MemoryCacheEntryOptions {AbsoluteExpirationRelativeToNow = System.TimeSpan.FromMinutes(5)});
            /*foreach (Data.Jewelry jewelry in jewelries)
            {
                AddToCache(jewelry);
            }*/
        }

        /// <summary>
        /// Gets from cache.
        /// </summary>
        /// <returns>List of jewelries</returns>
        public IEnumerable<Data.Jewelry> GetFromCache()
        {

            List<Data.Jewelry> jewelries = null;
            cache.TryGetValue("jewelry", out jewelries);
            /*int i = 1;
            while (true)
            {
                var model = GetFromCacheById(i++);
                if (model == null)
                {
                    break;
                }

                jewelries.Add(model);
            }
            */
            return jewelries;
        }

        /// <summary>
        /// Gets from cache by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>Jewelry</returns>
        public Data.Jewelry GetFromCacheById(int Id)
        {
            Data.Jewelry jewelry = null;
            cache.TryGetValue("jewelry", out jewelry);
            return jewelry;
        }

        /// <summary>
        /// Adds to cache.
        /// </summary>
        /// <param name="jewelry">The jewelry.</param>
        public void AddToCache(Data.Jewelry jewelry)
        {
            var timeout = configuration.GetSection("Cache").GetValue<int>("timeout");
            cache.Set(jewelry.Id, jewelry,
                new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = System.TimeSpan.FromMinutes(timeout) });
        }
    }
}
