// <copyright file="ExchangeRateNullException.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Business.Errors
{
    #region Usings
    using System;
    using System.Runtime.Serialization;
    #endregion

    /// <summary>
    /// Exchange Rate Null Exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ExchangeRateNullException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeRateNullException"/> class.
        /// </summary>
        public ExchangeRateNullException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeRateNullException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ExchangeRateNullException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeRateNullException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ExchangeRateNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeRateNullException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected ExchangeRateNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
