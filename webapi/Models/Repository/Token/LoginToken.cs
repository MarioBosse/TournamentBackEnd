using webapi.Models.Database.Users;

namespace webapi.Models.Repository.Token
{
    public class LoginToken
    {
        public long IdUser { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public LoginToken(User user)
        {
            this.IdUser = user.IdUser;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
        }
    }
}
