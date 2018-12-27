// <copyright file="ShapeService.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Business.ShapeService
{
    #region Usings
    using Jewelry.Common;
    using Jewelry.Database.ShapeRepository;
    #endregion
    /// <summary>
    /// Shape service
    /// </summary>
    /// <seealso cref="Jewelry.Business.ShapeProvider.IShapeService" />
    public class ShapeService : IShapeService
    {
        #region Private fields
        /// <summary>
        /// The shape repository
        /// </summary>
        private readonly IShapeRepository shapeRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeService"/> class.
        /// </summary>
        /// <param name="shapeRepository">The shape repository.</param>
        public ShapeService(IShapeRepository shapeRepository)
        {
            this.shapeRepository = shapeRepository;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Inserts the shape.
        /// </summary>
        /// <param name="shape">The shape.</param>
        public void InsertShape(Shape shape)
        {
            if (shape.Name != null && shape.Name != string.Empty)
            {
                this.shapeRepository.Insert(shape);
            }
        }
        #endregion
    }
}
