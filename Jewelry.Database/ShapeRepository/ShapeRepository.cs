// <copyright file="ShapeRepository.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Database.ShapeRepository
{
    #region Usings
    using System.Data.SqlClient;
    using Jewelry.Common;
    using Microsoft.Extensions.Configuration;
    #endregion

    /// <summary>
    /// Shape repository class
    /// </summary>
    /// <seealso cref="Jewelry.Database.ShapeRepository.IShapeRepository" />
    public class ShapeRepository : IShapeRepository
    {
        #region Private fields
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string connectionString;

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRepository"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ShapeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("DefaultConnection");
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Inserts the specified shape.
        /// </summary>
        /// <param name="shape">The shape.</param>
        public void Insert(Shape shape)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                string sqlExpression = "InsertShape";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", shape.Name);
                if (shape.SubShapeId != null)
                {
                    command.Parameters.AddWithValue("@subtypeId", shape.SubShapeId);
                }

                var result = command.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
