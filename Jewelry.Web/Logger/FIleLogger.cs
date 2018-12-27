// <copyright file="FileLogger.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Web.Logger
{
    #region Usings 
    using System;
    using System.IO;
    using Microsoft.Extensions.Logging;
    #endregion

    /// <summary>
    /// FileLogger class
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Logging.ILogger" />
    public class FileLogger : ILogger
    {
        /// <summary>
        /// The file path
        /// </summary>
        private string filePath;

        /// <summary>
        /// The lock
        /// </summary>
        private object lockObject = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public FileLogger(string path)
        {
            this.filePath = path;
        }

        /// <summary>
        /// Begins a logical operation scope.
        /// </summary>
        /// <typeparam name="TState">TState logger</typeparam>
        /// <param name="state">The identifier for the scope.</param>
        /// <returns>
        /// An IDisposable that ends the logical operation scope on dispose.
        /// </returns>
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        /// <summary>
        /// Checks if the given <paramref name="logLevel" /> is enabled.
        /// </summary>
        /// <param name="logLevel">level to be checked.</param>
        /// <returns>
        ///   <c>true</c> if enabled.
        /// </returns>
        public bool IsEnabled(LogLevel logLevel)
        {
                return true;
        }

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <typeparam name="TState">Logger state</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">Id of the event.</param>
        /// <param name="state">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a <c>string</c>message of the <paramref name="state" />and<paramref name="exception" />.</param>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null && IsEnabled(logLevel))
            {
                lock (this.lockObject)
                {
                    File.AppendAllText(this.filePath, formatter(state, exception) + Environment.NewLine);
                }
            }
        }
    }
}
