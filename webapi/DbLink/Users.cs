using GiDlls;
using Newtonsoft.Json.Linq;
using webapi.Context;
using webapi.Models.Database.Building;
using webapi.Models.Database.Users;
using webapi.Models.Repository.Token;
using webapi.Models.Repository.Users;

namespace webapi.DbLink
{
    public class Users
    {
        private UserRoleContext _roleContext { get; set; }
        private IConfiguration _configuration { get; set; }

        public Users(UserRoleContext roleContext, IConfiguration configuration)
        {
            _roleContext = roleContext;
            _configuration = configuration;
        }

        public Int64 AddUser(Models.Database.Users.User usersValue)
        {
            if (usersValue == null || _roleContext == null || _roleContext.Users == null) return 0;
            _roleContext.Users.Add(usersValue);
            _roleContext.SaveChanges();

            return GetId(usersValue.Email);
        }

        public UserBase GetInfos(TokenCheck infos)
        {
            TokenConnexion tokenC = new ConnexionState(_roleContext, _configuration).GetConnexionState(infos);
            if (_roleContext == null || _roleContext.Users == null) return new UserBase() { TokenConnexion = new Models.Repository.Token.TokenConnexion() { } };
            User? user = _roleContext.Users.Where(e => e.Email == infos.Email).FirstOrDefault();
            if (user == null) return new UserBase() { TokenConnexion = tokenC };

            return new UserBase()
            {
                TokenConnexion = tokenC,
                Birthdate = user.Birthdate,
                Email = user.Email,
                FirstName = user.FirstName,
                Gender = user.Gender,
                LastName = user.LastName,
                ProfilePhoto = user.ProfilePhoto,
                IsActivated = user.IsActivated,
                IdAddress = user.IdAddress,
                userAddress = new Address(_roleContext).Get(user.IdAddress)
            };
        }

        public Int64 GetId(String email)
        {
            if (email == null || _roleContext == null || _roleContext.Users == null) return 0;
            var id = _roleContext.Users.Where(e => e.Email == email).FirstOrDefault().IdUser;

            return id;
        }
    }
}