//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : AuthenticationService.Managers
// Description : Cette espace effectue la gestion des authentifications dans les
//               applications gèré par GiMB.
//
//----------------------------------------------------------------------------------
using AuthenticationService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthenticationService.Managers
{
    public class GIMBServices
    {
        public string SecretKey { get; set; }

        #region Constructor
        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 11 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : Constructeur
        // Nom : GIMBServices
        // Description : Fonction contructeur pour la classe GIMBService. Cette classe est
        //               responsable de créer et de gèrer les jetons de connexion pour le
        //               application sous la supervision de GIMB.
        // Paramètres : Un (1) paramètre est envoyé au consstructeur. Il contient la clé de
        //              référence pour créer le jeton de connexion.
        //      String  secretKey   Contient la valeur de la clé secrete a utiliser pour
        //                          cet utilisateur.
        //
        //----------------------------------------------------------------------------------
        public GIMBServices(string secretKey)
        {
            SecretKey = secretKey;
        }
        #endregion

        #region Public Methods
        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 11 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : Bool    Retour VRAI ou FAUX pour indiquer si le jeton fourni est
        //                          valide ou non.
        // Nom : IsTokenValid
        // Description : Fonction utilisé pour déterminer si un jeton est valide ou non.
        //               Dans le cas ou le jeton est valide dans le temps la fonction retour
        //               vrai, dans le cas contraire la fonction retourne faux.
        // Paramètres : String  token   Contien le jeton à vérifier.
        //
        //----------------------------------------------------------------------------------
        public bool IsTokenValid(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("Given token is null or empty.");

            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 11 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : String  Résultat crypté du modele demandé.
        // Nom : GenerateToken
        // Description : Construit un jeton a partir des informations reçu dans le modèle
        //               qui les est contenu dans la variable model.
        // Paramètres :
        //      IAuthContainerModel model   Contien la structure dse données a encoder. Ces
        //                                  informations sont contenue dans les Claims du
        //                                  modele transmis.
        //
        //----------------------------------------------------------------------------------
        public string GenerateToken(IAuthContainerModel model)
        {
            if (model == null || model.Claims == null || model.Claims.Length == 0)
                throw new ArgumentException("Arguments to create token are not valid.");

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(model.Claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(model.ExpireMinutes)),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), model.SecurityAlgorithm)
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return token;
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 11 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : IEnumable<Claim>    Liste des variables contenue dans le jeton
        //                                      crypté.
        // Nom : GetTokenClaims
        // Description : Cette utilise un jeton crypté pour le décoder et resortir les
        //               valeurs a l'origine de son propre cryptage. Si le jeton transmis
        //               est invalide, une exeption sera lancé.
        // Paramètres :
        //      String  token   Contien le jeton à crypté.
        //
        //----------------------------------------------------------------------------------
        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("Given token is null or empty.");

            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                return tokenValid.Claims;
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }
        #endregion

        #region Private Methods
        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 11 Août 2023
        //
        // Niveau d'accès : Private
        // Base d'enregistrement : Aucun
        // Type de retour : SecurityKey Clé de sécurité fraichement créé.
        // Nom : GetSymetricSecurityKey
        // Description : Cette fonction construit une clé de sécurité unique pour un
        //               utilisateur qui n'en possède pas.
        // Paramètres : Aucun
        //
        //----------------------------------------------------------------------------------
        private SecurityKey GetSymmetricSecurityKey()
        {
            byte[] symmetricKey = Convert.FromBase64String(SecretKey);
            return new SymmetricSecurityKey(symmetricKey);
        }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 11 Août 2023
        //
        // Niveau d'accès : Private
        // Base d'enregistrement : Aucun
        // Type de retour : .TokenValidationParameters
        // Nom : GetTokenValidationParameters
        // Description : Retourne un objet de base contenant une nouvelle clé de sécurité.
        // Paramètres : Aucun.
        //
        //----------------------------------------------------------------------------------
        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = GetSymmetricSecurityKey()
            };
        }
        #endregion
    }
}