namespace Jewelry.Business.LoginService.Authentication
{
    using System.Security.Principal;
    using System.Web;
    using Jewelry.Business.LoginService.Models;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// IUserAuthentication
    /// </summary>
    public interface IUserAuthentication
    {
        /// <summary>
        /// Gets or sets the HTTP context.
        /// </summary>
        /// <value>
        /// The HTTP context.
        /// </value>
        HttpContext httpContext { get; set; }

        /// <summary>
        /// Authentications the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="isPersistent">if set to <c>true</c> [is persistent].</param>
        /// <returns></returns>
        bool Authentication(User user, bool isPersistent = false);

        /// <summary>
        /// Registrations the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        void Registration(User user);

        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        IPrincipal CurrentUser { get; }
    }
}
