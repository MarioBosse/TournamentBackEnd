//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Controllers
// API Controleur : Joueurs
// Description : Classe controleur qui expose des fontions qui seront appelé par
//               l'application Web.
//
//----------------------------------------------------------------------------------using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using webapi.Context;
using webapi.Models.Repository.Token;

namespace webapi.Controllers
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class Controleur
    // Nom : JoueursController
    // Héritage : Controler
    // Définition de route : Api/User
    //
    //----------------------------------------------------------------------------------
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
