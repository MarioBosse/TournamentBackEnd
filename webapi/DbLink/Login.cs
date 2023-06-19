using webapi.Context;
using webapi.Models;
using webapi.Models.Users;

namespace webapi.DbLink
{
    public class Login
    {
        private readonly UserRoleContext _roleContext;
        public Login(UserRoleContext roleContext)
        {
            _roleContext = roleContext;
        }

        public Boolean IsLoggedIn
        {
            get;
        }

        public List<User> GetAlls()
        {
            if (_roleContext == null || _roleContext.Users == null) return new List<User>();

            return _roleContext.Users.Where(e => e.IdUser > 0).ToList<User>();

        }
        public Boolean EmailExisting(String email)
        {
            if(_roleContext == null || _roleContext.Users == null) return false;

            return _roleContext.Users.Where(e => e.Email == email).Any();
        }

        public User? CheckConnection(LoginSend loginSend)
        {
            if (_roleContext == null || _roleContext.Users == null) return null;

            var val = _roleContext.Users.Where(e => e.Email == loginSend.Email && e.Password == loginSend.Password).FirstOrDefault();

            // Création d'un Token et enregistrement de celui-ci
            return val;
        }
    }
}
