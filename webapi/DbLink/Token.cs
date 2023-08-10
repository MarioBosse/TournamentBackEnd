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
        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 4 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : Constructeur
        // Nom : Token
        // Description : Classe qui contruit un jeton de sécurité à partir de données
        //               d'utilisateur utilisé pour effectuer la connexion avec le service
        //               de gestion de la base de données.
        // Paramètres :
        //      UserRoleContext context         Pointe sur le DbContext de la base de
        //                                      données du projet.
        //
        //----------------------------------------------------------------------------------
        public Token(UserRoleContext context)
        {
            _roleContext = context;
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 4 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : Strign
        // Nom : GetSecurityKey
        // Description : Fonction contructeur pour la classe Tournament. Cette classe
        //               effectue tous les appels et le traitement des données en lien avec
        //               les définitions de tournoi.
        // Paramètres : 
        //      User    user    Structure contenant les informations de l'utilisateur a
        //                      utiliser pour créer le jeton de sécurité.
        //
        //----------------------------------------------------------------------------------
        public String GetSecurityKey(User user)
        {
            if (_roleContext.Tokens.Count() == 0) return "";

            var sec = new Token(_roleContext).GetSecurityKey(user);

            var usr = _roleContext.Tokens.Where(e => e.IdUser == user.IdUser).FirstOrDefault();
            return (usr != null ? usr.SecurityToken : "");
        }

        //public String AddSecurityKey(Int64 userId, String securityKey)
        //{
        //    _roleContext.Tokens.Add(new Models.Database.Users.Token() { IdUser = userId, SecurityToken = securityKey });
        //    _roleContext.SaveChanges();
        //    return securityKey;
        //}
    }
}
