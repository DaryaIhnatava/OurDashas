// <copyright file="FileLoggerProvider.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Web.Logger
{
    #region Usings 
    using Microsoft.Extensions.Logging;
    #endregion

    /// <summary>
    /// FileLoggerProvider class
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Logging.ILoggerProvider" />
    public class FileLoggerProvider : ILoggerProvider
    {
        /// <summary>
        /// The path
        /// </summary>
        private string path;

        /// <summary>
        /// The logger
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLoggerProvider"/> class.
        /// </summary>
        /// <param name="path">The path of file</param>
        public FileLoggerProvider(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Creates a new <see cref="T:Microsoft.Extensions.Logging.ILogger" /> instance.
        /// </summary>
        /// <param name="categoryName">The category name for messages produced by the logger.</param>
        /// <returns>ILogger object</returns>
        public ILogger CreateLogger(string categoryName)
        {
            //if (logger != null)
            //{
            //    logger = new FileLogger(this.path);
            //}
            //return logger;
            return new FileLogger(path);
        }
        
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
