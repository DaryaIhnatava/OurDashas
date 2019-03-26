// <copyright file="Filter.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Business.FilterService
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    #endregion

    /// <summary>
    /// Filter class
    /// </summary>
    /// <typeparam name="T">Used jewelry</typeparam>
    public class Filter<T> 
    {
        /// <summary>
        /// Filters the by expression.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="values">The values.</param>
        /// <returns>Filtered jewelries</returns>
        public static IEnumerable<T> FilterByExpression(IQueryable<T> list, string propertyName, params object[] values)
        {
            Expression<Func<T, bool>> expressionForFilter = GetExpression(propertyName, values);
            return list.Where(expressionForFilter);
        }

        /// <summary>
        /// Gets the expression.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="values">The values.</param>
        /// <returns>Expression for filtering</returns>
        private static Expression<Func<T, bool>> GetExpression(string propertyName, params object[] values)
        {
            var parameter = Expression.Parameter(typeof(T), "item");
            var property = Expression.PropertyOrField(parameter, propertyName);
            var body = Expression.Equal(property, Expression.Constant(values[0]));

            for (int i = 1; i < values.Length; i++)
            {
                body = Expression.Or(body, Expression.Equal(property, Expression.Constant(values[i])));
            }

            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
            return lambda;
        }
    }
}
