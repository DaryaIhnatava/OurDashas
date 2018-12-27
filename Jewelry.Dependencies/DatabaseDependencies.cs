// <copyright file="DatabaseDependencies.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Dependencies
{
    #region Usings
    using Jewelry.Business.Service;
    using Jewelry.Business.ShapeService;
    using Microsoft.Extensions.DependencyInjection;
    #endregion

    /// <summary>
    /// Class for database registry dependencies
    /// </summary>
    public static class DatabaseDependencies
    {
        /// <summary>
        /// Adds the jewelry database registries.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddJewelryDatabaseRegistries(this IServiceCollection services)
        {
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IShapeService, ShapeService>();
        }
    }
}
