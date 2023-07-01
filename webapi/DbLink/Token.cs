using webapi.Context;
using webapi.Models.Users;

namespace webapi.DbLink
{
    public class Token
    {
        private readonly UserRoleContext _roleContext;
        public Token(UserRoleContext context)
        {
            _roleContext = context;
        }

        public String GetSecurityKey(User user)
        {
            if (_roleContext.Tokens.Count() == 0) return "";

            var sec = new Token(_roleContext).GetSecurityKey(user);

            var usr = _roleContext.Tokens.Where(e => e.IdUser == user.IdUser).FirstOrDefault();
            return (usr != null ? usr.SecurityToken : "");
        }

        public String AddSecurityKey(Int64 userId, String securityKey)
        {
            _roleContext.Tokens.Add(new Models.Users.Token() { IdUser = userId, SecurityToken = securityKey });
            _roleContext.SaveChanges();
            return securityKey;
        }
    }
}
