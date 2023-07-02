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
