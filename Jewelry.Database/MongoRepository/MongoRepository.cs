namespace Jewelry.Database.MongoRepository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MongoDB.Bson;
    using MongoDB.Driver;

    /// <summary>
    /// Mongo repository
    /// </summary>
    /// <seealso cref="Jewelry.Database.MongoRepository.IMongoRepository" />
    public class MongoRepository : IMongoRepository
    {
        /// <summary>
        /// Inserts the specified jewelry.
        /// </summary>
        /// <param name="jewelry">The jewelry.</param>
        public void Insert(Data.Jewelry jewelry)
        {
            Jewelries.InsertOneAsync(jewelry);
        }

        public IEnumerable<Data.Jewelry> GetJewelriesAsync()
        {
            var model = Jewelries
                    .Find(_ => true).ToListAsync();
            model.Wait();
            return model.Result;
        }

        /// <summary>
        /// Filtering jewelries
        /// </summary>
        /// <param name="minPrice"></param>
        /// <param name="maxPrice"></param>
        /// <param name="name"></param>
        /// <returns>lis of jewelries</returns>
        public async Task<IEnumerable<Data.Jewelry>> GetJewelries(int? minPrice, int? maxPrice, string name)
        {
            var builder = new FilterDefinitionBuilder<Data.Jewelry>();
            var filter = builder.Empty;
            if (!String.IsNullOrWhiteSpace(name))
            {
                filter = filter & builder.Regex("Shape", new BsonRegularExpression(name));
            }
            if (minPrice.HasValue)
            {
                filter = filter & builder.Gte("Price", minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                filter = filter & builder.Lte("Price", maxPrice.Value);
            }

            return await Jewelries.Find(filter).ToListAsync();
        }

        /// <summary>
        /// Getting jewelry by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Jewelry</returns>
        public async Task<Data.Jewelry> GetJewelry(string Id)
        {
            return await Jewelries.Find(new BsonDocument("_id", new ObjectId(Id))).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Updating jewelry 
        /// </summary>
        /// <param name="jewelry"></param>
        public async Task Update(Data.Jewelry jewelry)
        {
            await Jewelries.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(jewelry.Id)), jewelry);
        }

        /// <summary>
        /// Removing jewelry
        /// </summary>
        /// <param name="Id"></param
        /// <returns></returns>
        public async Task Remove(string Id)
        {
            await Jewelries.DeleteOneAsync(new BsonDocument("_id", new ObjectId(Id)));
        }

        /// <summary>
        /// Gets the jewelries.
        /// </summary>
        /// <value>
        /// The jewelries.
        /// </value>
        private IMongoCollection<Data.Jewelry> Jewelries
        {
            get {
                return JewelryContext.DatabaseClient.GetCollection<Data.Jewelry>("Jewelries");
            }
        }



    }
}
