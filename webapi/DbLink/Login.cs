using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using webapi.Context;
using webapi.Models;
using webapi.Models.Users;
using webapi.Token;

namespace webapi.DbLink
{
    public class Login
    {
        private readonly UserRoleContext _roleContext;
        private readonly IConfiguration _configuration;
        public Login(UserRoleContext roleContext, IConfiguration configuration)
        {
            _roleContext = roleContext;
            _configuration = configuration;
        }

        public Boolean IsLoggedIn
        {
            get;
        }

        public List<User> GetAlls()
        {
            if (_roleContext == null || _roleContext.Users == null) return new List<User>();
            var ret = _roleContext.Users.Where(e => e.IdUser > 0).ToList();
            return ret;
        }
        public Boolean EmailExisting(String email)
        {
            if(_roleContext == null || _roleContext.Users == null) return false;

            return _roleContext.Users.Where(e => e.Email == email).Any();
        }

        public Models.Users.Token? CheckConnection(LoginSend loginSend)
        {
            if (_roleContext == null || _roleContext.Users == null) return null;

            var val = _roleContext.Users.Where(e => e.Email == loginSend.Email && e.Password == loginSend.Password).FirstOrDefault();

            if (val == null) return null;

            var myT = new MyToken(_configuration);
            var tok = myT.GetToken(val);
            var t = new Models.Users.Token();
            t.IdUser = val.IdUser;
            return t;
        }
    }
}
