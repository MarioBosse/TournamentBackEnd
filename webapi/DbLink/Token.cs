//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.DbLink
// Description : Cette classe effectue le lien entre les controleurs et les différents
//               DbContext lié au Jeton et aux accèss des services de l'application
//               de gestion de la base de données.
//
//----------------------------------------------------------------------------------
using webapi.Context;
using webapi.Models.Database.Users;

namespace webapi.DbLink
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : Token
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
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
            _roleContext.Tokens.Add(new Models.Database.Users.Token() { IdUser = userId, SecurityToken = securityKey });
            _roleContext.SaveChanges();
            return securityKey;
        }
    }
}
