//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 12 Août 2023
//
// Nom : webapi.Controllers
// API controleurs : TournamentType
// Description : Classe controleur qui expose des fontions qui seront appelé par
//               l'application Web.
//
//----------------------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webapi.Context;
using webapi.DbLink;
using webapi.Models.Repository.Token;
using webapi.Models.Repository.Tournament.Types;

namespace webapi.Controllers
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 12 Août 2023
    //
    // Définition de Class Controleur
    // Nom : TournamentTypesController
    // Héritage : Controller
    // Définition de route : Api/Tournament/Types
    //
    //----------------------------------------------------------------------------------
    [ApiController]
    [Route("Api/Tournament/Types/")]
    public class TournamentTypesController : Controller
    {
        private readonly UserRoleContext _roleContext;
        private readonly IConfiguration _configuration;

        public TournamentTypesController(UserRoleContext roleContext, IConfiguration configuration)
        {
            _roleContext = roleContext;
            _configuration = configuration;
        }

        [Route("AllTypes")]
        public ActionResult GetAllTypes(TokenCheck tokenCheck)
        {
            return Ok(JsonConvert.SerializeObject(new Tournament(_roleContext, _configuration).GetAllTypes(tokenCheck)));
        }

        [Route("Add")]
        public ActionResult TournamentTypeAdd(TournamentTypeAddRead type)
        {
            return Ok(new Tournament(_roleContext, _configuration).TournamentTypeAdd(type));
        }

        [Route("Delete")]
        public ActionResult TournamentTypeDelete(TournamentTypeDelete delete)
        {
            return Ok(new Tournament(_roleContext, _configuration).TournamentTypeDelete(delete));
        }

        [Route("Modify")]
        public ActionResult TournamentTypeModify(TournamentTypeModify modify)
        {
            return Ok(new Tournament(_roleContext, _configuration).TournamentTypeModify(modify));
        }

        [Route("Read")]
        public ActionResult TournamentTypeRead()
        {
            return Ok();
        }
    }
}
