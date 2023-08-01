//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Repository.Token
// Description : Classes qui régis les valeurs d'entrées requise pour effectuer
//               une connexion stable et sécuritaire entre l'application et les
//               services de gestion de la base de données.
//
//----------------------------------------------------------------------------------
using webapi.Models.Repository.Roles;

namespace webapi.Models.Repository.Token
{
    public class TokenCheck
    {
        public String Email { get; set; } = String.Empty;
        public String Token { get; set; } = String.Empty;
    }

    public class LoginUser
    {
        public TokenCheck tokenCheck { get; set; } = new TokenCheck();
        public String? photoProfile { get; set; } = null;
        public String Firstname { get; set; } = String.Empty;
        public String Lastname { get; set; } = String.Empty;
        public RolesBase RolesBase { get; set; } = new RolesBase();
        public TokenConnexion TokenConnexion { get; set; } = new TokenConnexion();
    }
}
