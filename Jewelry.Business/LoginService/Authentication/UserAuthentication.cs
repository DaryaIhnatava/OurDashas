namespace Jewelry.Business.LoginService.Authentication
{
    using System;
    using System.Linq;
    using System.Security.Principal;
    using Jewelry.Business.LoginService.Models;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    /// <summary>
    /// UserAuthentication
    /// </summary>
    /// <seealso cref="Jewelry.Business.LoginService.Authentication.IUserAuthentication" />
    public class UserAuthentication : IUserAuthentication
    {
        /// <summary>
        /// The cookiename
        /// </summary>
        private string cookiename = "authCookie";

        /// <summary>
        /// The user service
        /// </summary>
        private readonly IService<User> userService;


        /// <summary>
        /// Initializes a new instance of the <see cref="UserAuthentication"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <exception cref="ArgumentNullException">userService</exception>
        public UserAuthentication(IService<User> userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// Gets or sets the HTTP context.
        /// </summary>
        /// <value>
        /// The HTTP context.
        /// </value>
        public HttpContext httpContext { get; set; }


        /// <summary>
        /// Registrations the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Registration(User user)
        {
            if (user != null)
            {
                CreateCookie(user);
            }
        }

        public bool Authentication(User newUser, bool isPersistent = false)
        {
            if (newUser == null || newUser.Email == null || newUser.Password == null)
                return false;
            User user = GetUser(newUser.Email);
            if (user != null && Encryption.VerifyMd5Hash(newUser.Password, user.Password))
            {
                CreateCookie(user, isPersistent);
                return true;
            }
            return false;
        }
        private User GetUser(string login)
        {
            return userService.ListByProperty("Email", login).FirstOrDefault();
        }

        private void CreateCookie(User user, bool isPersistent = false)
        {
            var value = JsonConvert.SerializeObject(GetUser(user));
            httpContext.Response.Cookies.Append(cookiename, value);
        }


        private IPrincipal _currentUser;

        public IPrincipal CurrentUser
        {
            get
            {
                if (_currentUser == null || !_currentUser.Identity.IsAuthenticated)
                {
                    try
                    {
                        var authCookie = httpContext.Request.Cookies[cookiename];
                        User user = JsonConvert.DeserializeObject<User>(authCookie);
                        if (authCookie != null && !string.IsNullOrEmpty(authCookie))
                        {
                            _currentUser = new UserProvider.UserProvider(userService, user);
                        }
                        else
                        {
                            _currentUser = new UserProvider.UserProvider( null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        _currentUser = new UserProvider.UserProvider( null, null);
                    }
                }

                else if (_currentUser != null)
                {
                    try
                    {
                        var authCookie = httpContext.Request.Cookies[cookiename];
                        User user = JsonConvert.DeserializeObject<User>(authCookie);
                        if (authCookie != null && !string.IsNullOrEmpty(authCookie))
                        {
                            _currentUser = new UserProvider.UserProvider(userService, user);
                        }
                        else
                        {
                            _currentUser = new UserProvider.UserProvider(null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        _currentUser = new UserProvider.UserProvider(null, null);
                    }
                }
                return _currentUser;
            }
        }

        private Models.User GetUser(User user)
        {
            return new Models.User()
            {
                Id= user.Id,
                Email = user.Email
            };
        }
    }
}
