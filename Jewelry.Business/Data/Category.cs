// <copyright file="JewelryExtension.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.Resources;
using Jewelry.Business.i18n;

namespace Jewelry.Business.Data
{
    #region Usings
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Category class
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Category property
        /// </summary>
        public Category()
        {
            this.PropertyValues = new List<Value>();
        }

        /// <summary>
        /// PropertyName property
        /// </summary>
        //[Display(Name  = Resource.PropertyName)]
        public string PropertyName { get; set; }

        /// <summary>
        /// PropertyValues property
        /// </summary>
        public List<Value> PropertyValues { get; set; }
    }
}
