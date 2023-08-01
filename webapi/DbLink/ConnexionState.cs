//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.DbLink
// Description : Classe qui régis les valeurs de retour pour toutes les appels d'API
//               effectués. L'objet retournée informe l'application du status de la
//               liaison entre celle-ci et les services offert qu'elle a besoin.
//
//----------------------------------------------------------------------------------
using webapi.Context;
using webapi.Models.Repository.Token;

namespace webapi.DbLink
{
    public class ConnexionState
    {
        private UserRoleContext _roleContext;
        private IConfiguration _configuration;

        public ConnexionState(UserRoleContext userRoleContext, IConfiguration configuration)
        {
            _roleContext = userRoleContext;
            _configuration = configuration;
        }

        public TokenConnexion GetConnexionState(TokenCheck tokenCheck)
        {
            TokenConnexion token = new TokenConnexion();
            TokenValidation? isValide = new Login(_roleContext, _configuration).IsConnexionValid(tokenCheck);
            if (isValide == null || !isValide.IsValid) return new TokenConnexion() { IsConnected = false, ConnexionCode = -1, Message = "Invalid or expired connexion" };

            token.IsConnected = isValide.IsValid;
            token.ConnexionCode = 101;
            token.Message = "Connexion is active";
            return token;
        }
    }
}
