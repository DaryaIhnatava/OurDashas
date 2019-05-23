// <copyright file="ErrorViewModel.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Web.Models
{
    using System;

    /// <summary>
    /// ErrorViewModel class
    /// </summary>
    public class ErrorViewModel 
    {
        /// <summary>
        /// Gets statusCode
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets InnerException
        /// </summary>
        public Exception InnerException { get; set; }

        /// <summary>
        /// Gets message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets shape of jewelry
        /// </summary>
        public string HelpLink { get; set; }

        /// <summary>
        /// Gets source
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets stackTrace
        /// </summary>
        public string StackTrace { get; set; }
    }
}