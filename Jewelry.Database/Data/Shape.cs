// <copyright file="Shape.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Database.Data
{
    #region Usings
    using System.ComponentModel.DataAnnotations;
    using NHibernate.Mapping.Attributes;
    #endregion
    /// <summary>
    /// Shape class
    /// </summary>
    [Class]
    public class Shape
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Id(0, Name="Id")]
        [Generator(1, Class = "identity")]
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Property]
        public virtual string Name { get; set; }
    }
}
