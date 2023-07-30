//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// API Controleur : Login
// Description : Ce controleur offre les fonction pour :
//      - vérifier,
//      - indentifier,
//      - et créer une connexion stable et sécuritaire.
//
//----------------------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using webapi.Context;
using webapi.DbLink;
using webapi.Models.Repository.Login;
using webapi.Models.Repository.Token;

namespace webapi.Controllers
{
    [ApiController]
    [Route("Api/Login/")]
    public class LoginController : ControllerBase
    {
        #region Private & Constructor
        private readonly UserRoleContext _roleContext;
        private readonly IConfiguration _configuration;

        public LoginController(UserRoleContext roleContext, IConfiguration configuration)
        {
            _roleContext = roleContext;
            _configuration = configuration;
        }
        #endregion

        #region Api/Login/All
        //----------------------------------------------------------------------------------
        //
        // Gestion Informatique Mario Bossé (GiMB)
        // @2023 Tout droit réservé. Reproducion interdite
        //
        // Concepteur : Mario Bossé
        // 16 Juillet 2023
        //
        // API : Api/Login/All
        // Description : Donne la liste de tous les courriels enregistrés pour un évènement.
        //               Cette liste est disponible si le client est administrateur de cet
        //               évènement. Si le client est administrateur de plusieurs évenement,
        //               cet API retourne la liste des inscriptions de chaque évènement.
        //
        // Paramêtre :
        //      - Email : Adresse courriel du client à vérifier
        //      - Token : Jeton de sécurité donnant accès aux informations. Si le jeton est
        //                valide, une vérification des tournois en cours et a venir est
        //                effectué avec le client en références. Si le client est un des
        //                administrateur de ces évènement, la liste des inscriptions est
        //                autorisé a être retournée./
        //
        // Structure de retour:
        //      {
        //      }
        //
        //----------------------------------------------------------------------------------
        [Route("All")]
        public ActionResult GetAll(TokenCheck token)
        {
            return Ok(new Login(_roleContext, _configuration).GetAlls(token));
        }
        #endregion
        #region Api/Login/CreateConnexion
        //----------------------------------------------------------------------------------
        //
        // Gestion Informatique Mario Bossé (GiMB)
        // @2023 Tout droit réservé. Reproducion interdite
        //
        // Concepteur : Mario Bossé
        // 16 Juillet 2023
        //
        // API : Api/Login/CreateConnexion
        // Description : Appel utilisé pour créer une connexion avec la base de données et
        //               les services de l'application. Cette fonction retourne un jeton de
        //               connexion qui confirme le succès des informations saisie.
        //
        // Paramêtre :
        //      - Email : Adresse courriel saisie dans le front-end. Cette adresse soit
        //                être présente dans la base de données. Le mot de passe qui
        //                suivra confirmera la connexion du client.
        //      - Password : Mot de passe saisie dans le front-end. Avec la combinaison du
        //                courriel, celui-ci va confirmer la connexion entre la page web et
        //                le service.
        //
        // Structure de retour:
        //      {
        //          "tokenCheck" :
        //          {
        //              "Email" : "",
        //              "Token" : ""
        //          },
        //          "photoProile" : base64 String,
        //          "Firstname" : "",
        //          "Lasename" : "",
        //          "tokenConnexion" :
        //          {
        //              "isConnected" : true, false,
        //              "connexionCode" = 0,
        //              "Message" : ""
        //           }
        //      }
        //
        //----------------------------------------------------------------------------------
        [Route("CreateConnexion")]
        public ActionResult CreateConnexion(LoginSend info)
        {
            return Ok(new Login(_roleContext, _configuration).GetConnection(info));
        }
        #endregion
        #region Api/Login/IsValidConnexion
        //----------------------------------------------------------------------------------
        //
        // Gestion Informatique Mario Bossé (GiMB)
        // @2023 Tout droit réservé. Reproducion interdite
        //
        // Concepteur : Mario Bossé
        // 16 Juillet 2023
        //
        // API : Api/
        // Description : Cette fonction utlise le jeton jumelé avec l'addresse courriel
        //               pour valider si la connexion du jeton est toujours valide.
        //
        // Paramêtre :
        //      - Email : Courriel du client a vérifer.
        //      - Token : Jeton de vérification pour la validité de la connexion.
        //
        // Structure de retour:
        //      {
        //          "isValid" : true, false,
        //          "tokenConnexion" :
        //          {
        //              "isConnected : true,false,
        //              "connexionCode : 0,
        //              "Message" : ""
        //          }
        //      }
        //
        //----------------------------------------------------------------------------------
        [Route("IsValidConnexion")]
        public ActionResult IsValidConnection(TokenCheck info)
        {
            return Ok(new Login(_roleContext, _configuration).IsConnexionValid(info));
        }
        #endregion
        #region Api/Login/Email
        //----------------------------------------------------------------------------------
        //
        // Gestion Informatique Mario Bossé (GiMB)
        // @2023 Tout droit réservé. Reproducion interdite
        //
        // Concepteur : Mario Bossé
        // 16 Juillet 2023
        //
        // API : Api/Login/Email
        // Description : Cette fonction est utilisé pour vérifier si une adresse courriel
        //               est présente dans la base de données.
        //
        // Paramêtre :
        //      - Email : Addresse courriel a vérifier.
        //
        // Structure de retour:
        //      {
        //          "Value" : true, false
        //      }
        //
        //----------------------------------------------------------------------------------
        [Route("Email")]
        public ActionResult CheckEmail(EmailCheck courriel)
        {
            return Ok(new Login(_roleContext, _configuration).EmailExisting(courriel.Email));
        }
        #endregion
    }
}
