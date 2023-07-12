using GiDlls;
using webapi.Context;
using webapi.Models.Database.Building;
using webapi.Models.Database.Users;

namespace webapi.DbLink
{
    public class Users
    {
        private UserRoleContext _roleContext { get; set; }

        public Users(UserRoleContext roleContext)
        {
            _roleContext = roleContext;
        }

        public Int64 AddUser(Models.Database.Users.User usersValue)
        {
            if (usersValue == null || _roleContext == null || _roleContext.Users == null) return 0;
            _roleContext.Users.Add(usersValue);
            _roleContext.SaveChanges();

            return GetId(usersValue.Email);
        }

        public Int64 GetId(String email)
        {
            if (email == null || _roleContext == null || _roleContext.Users == null) return 0;
            var id = _roleContext.Users.Where(e => e.Email == email).FirstOrDefault().IdUser;

            return id;
        }
    }
}