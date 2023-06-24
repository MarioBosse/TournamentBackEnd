using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using webapi.Context;
using webapi.Models.CRUD.Token;
using webapi.Models.Repository;
using webapi.Models.Repository.Login;
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

        public List<AllUsers> GetAlls()
        {
            if (_roleContext == null || _roleContext.Users == null || _roleContext.Addresses == null) return new List<AllUsers>();
            var alls = _roleContext.Users.Where(e => e.IdUser > 0).ToList();

            List<AllUsers> allUsers = new List<AllUsers>();
            foreach(var user in alls)
            {
                var ad = _roleContext.Addresses.Where(e => e.IdAddress == user.IdAddress).FirstOrDefault();
                if (ad == null) continue;

                allUsers.Add(new AllUsers() { FirstName = user.FirstName,
                                              LastName = user.LastName,
                                              Email = user.Email,
                                              Gender = user.Gender,
                                              IsActivated = user.IsActivated,
                                              ProfilePhoto = user.ProfilePhoto,
                                              Address = new DataObjectTransfert().GetAddress(ad, _roleContext)
                });
            }
            return allUsers;
        }
        public VraiFaux EmailExisting(String email)
        {
            var VF = new VraiFaux();
            if (_roleContext == null || _roleContext.Users == null) { VF.Value = false; return VF; }

            VF.Value = _roleContext.Users.Where(e => e.Email == email).Any();
            return VF;
        }

        public TokenRead? GetConnection(LoginSend loginSend)
        {
            if (_roleContext == null || _roleContext.Users == null) return null;

            TokenRead TR = new TokenRead();

            var val = _roleContext.Users.Where(e => e.Email == loginSend.Email && e.Password == loginSend.Password).FirstOrDefault();

            if (val == null) return null;

            var myT = new MyToken(_roleContext, _configuration);
            var tok = myT.GetToken(val);

            TR.Token = tok;
            TR.Email = loginSend.Email;
            return TR;
        }
    }
}
