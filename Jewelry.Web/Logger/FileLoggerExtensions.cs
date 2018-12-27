// <copyright file="FileLoggerExtensions.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Web.Logger
{
    #region Usings
    using Microsoft.Extensions.Logging;
    #endregion

    /// <summary>
    /// FileLoggerExtensions class
    /// </summary>
    public static class FileLoggerExtensions
    {
        /// <summary>
        /// Adds the file.
        /// </summary>
        /// <param name="factory">The logger factory</param>
        /// <param name="path">The path of logger file</param>
        /// <returns>ILoggerFactory object</returns>
        public static ILoggerFactory AddFile(this ILoggerFactory factory, string path)
        {
            factory.AddProvider(new FileLoggerProvider(path));
            return factory;
        }
    }
}
