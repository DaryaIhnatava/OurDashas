namespace Jewelry.Business.LoginService.UserProvider
{
    using System.Security.Principal;
    using Jewelry.Business.LoginService.Models;
    using Jewelry.Business.LoginService.UserIdentity;

    public class UserProvider:IPrincipal
    {
        private readonly IService<User> userService;
        public UserProvider(IService<User> userService, User user)
        {
            this.userService = userService;

            userIndentity = new UserIdentity(userService);
            userIndentity.User = user;
        }

        private UserIdentity userIndentity { get; set; }

        public IIdentity Identity
        {
            get
            {
                return userIndentity;
            }
        }
        public bool IsInRole(string role)
        {
            return true;
        }
    }
}
