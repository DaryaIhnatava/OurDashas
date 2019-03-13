namespace Jewelry.Business.Data
{
    #region Usings
    using System.Collections.Generic;
    using System.Linq;
    #endregion

    public static class JewellryExtension
    {
        /// <summary>
        /// Orders the name of the by property.
        /// </summary>
        /// <param name="jewellries">The jewellries.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static IEnumerable<Jewellry> OrderByPropertyName(this IEnumerable<Jewellry> jewellries, string propertyName)
        {
            var property = typeof(Jewellry).GetProperty(propertyName);
            return jewellries.OrderBy(x => property.GetValue(x));
        }
    }
}
