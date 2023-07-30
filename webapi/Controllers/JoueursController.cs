//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// API Controleur : Joueurs
// Description : Ce controleur offre les fonction pour :
//      - vérifier,
//      - indentifier,
//      - et créer,
//      - modifier ou
//      - supprimer un joueur, participant ou client.
//
//----------------------------------------------------------------------------------using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using webapi.Context;
using webapi.Models.Repository.Token;
using webapi.Models.Repository.Users;

namespace webapi.Controllers
{
    [ApiController]
    [Route("Api/Users/")]
    public class JoueursController : Controller
    {
        #region Private & Constructor
        private IConfiguration _configuration;
        private UserRoleContext _roleContext;

        public JoueursController(UserRoleContext roleContext, IConfiguration configuration)
        {
            _roleContext = roleContext;
            _configuration = configuration;
        }
        #endregion
        #region Api/Users/GetInfos
        [Route("GetInfos")]
        public ActionResult GetUserInformation(TokenCheck infos)
        {
            return Ok(new DbLink.Users(_roleContext, _configuration).GetInfos(infos));
        }
        #endregion
    }
}
