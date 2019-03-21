// <copyright file="IShapeRepository.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Database.ShapeRepository
{
    #region Usings
    using Jewelry.Database.Data;
    #endregion

    /// <summary>
    /// Shape Interface
    /// </summary>
    public interface IShapeRepository
    {
        /// <summary>
        /// Inserts the specified shape.
        /// </summary>
        /// <param name="shape">The shape.</param>
        void Insert(Shape shape);
    }
}
