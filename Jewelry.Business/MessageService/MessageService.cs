// <copyright file="MessageService.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Business.MessageService
{
    /// <summary>
    /// Massage service
    /// </summary>
    /// <seealso cref="IMessageService" />
    public class MessageService : IMessageService
    {
        #region Public methods
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <returns>
        /// Message "Hello"
        /// </returns>
        public string GetMessage()
        {
            return "Hello";
        }
        #endregion
    }
}
