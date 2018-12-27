// <copyright file="BusinessDependencies.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Dependencies
{
    #region Usings
    using Jewelry.Database.ShapeRepository;
    using Microsoft.Extensions.DependencyInjection;
    #endregion

    /// <summary>
    /// Class for business dependencies registrations
    /// </summary>
    public static class BusinessDependencies
    {
        /// <summary>
        /// Adds the jewelry business registries.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddJewelryBusinessRegistries(this IServiceCollection services)
        {
            services.AddTransient<IShapeRepository, ShapeRepository>();
        }
    }
}