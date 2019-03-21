// <copyright file="Shape.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Database.Data
{
    #region Usings
    using System.ComponentModel.DataAnnotations;
    #endregion
    /// <summary>
    /// Shape class
    /// </summary>
    public class Shape
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the sub shape identifier.
        /// </summary>
        /// <value>
        /// The sub shape identifier.
        /// </value>
        public virtual int? SubShapeId { get; set; }
    }
}
