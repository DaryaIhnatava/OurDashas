namespace Jewelry.Database.MongoRepository
{

    using MongoDB.Driver;
    using MongoDB.Driver.GridFS;

    /// <summary>
    /// Jewelry context class
    /// </summary>
    public static class JewelryContext
    {
        /// <summary>
        /// The mongo database
        /// </summary>
        private static readonly IMongoDatabase mongoDatabase;
        /// <summary>
        /// The grid fs
        /// </summary>
        private static readonly IGridFSBucket gridFS;

        /// <summary>
        /// Initializes a new instance of the <see cref="JewelryContext"/> class.
        /// </summary>
        static JewelryContext()
        {
            string connectionString = "mongodb://localhost:27017/JewelryStore";
            var connection = new MongoUrlBuilder(connectionString);
            MongoClient client = new MongoClient(connectionString);
            mongoDatabase = client.GetDatabase(connection.DatabaseName);
            gridFS = new GridFSBucket(mongoDatabase);
        }

        /// <summary>
        /// Gets the database client.
        /// </summary>
        /// <value>
        /// The database client.
        /// </value>
        public static IMongoDatabase DatabaseClient => mongoDatabase;

    }
}
