namespace Jewelry.Business.LoginService.UserIdentity
{
    using System.Linq;
    using System.Security.Principal;
    using Jewelry.Business.LoginService.Models;

    public class UserIdentity : IIdentity
    {
        private readonly IService<User> userRepository;

        public UserIdentity(IService<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public User User { get; set; }

        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                if (User != null)
                    return User.Email;
                return "anonym";
            }

        }

        public void Init(string login)
        {
            if (!string.IsNullOrEmpty(login))
            {
                User =(User)userRepository.ListByProperty("Email", login).FirstOrDefault();
            }
        }
    }
}
