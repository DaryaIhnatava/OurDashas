// <copyright file="IShapeService.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Business.ShapeService
{
    #region Usings
    using Jewelry.Database.Data;
    #endregion

    /// <summary>
    /// Shape interface
    /// </summary>
    public interface IShapeService
    {
        /// <summary>
        /// Inserts the shape.
        /// </summary>
        /// <param name="shape">The shape.</param>
        void InsertShape(Shape shape);
    }
}
