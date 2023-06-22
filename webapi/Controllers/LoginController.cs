using Microsoft.AspNetCore.Mvc;
using webapi.Context;
using webapi.Models;

namespace webapi.Controllers
{

    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserRoleContext _roleContext;

        public LoginController(UserRoleContext roleContext)
        {
            _roleContext = roleContext;
        }
        // Donne la liste de tous les courriels enregistrés
        [Route("Api/Login/All")]
        public ActionResult GetAll()
        {
            return Ok(new DbLink.Login(_roleContext).GetAlls());
        }
        [Route("Api/Login/Check")]
        public ActionResult Check(LoginSend info)
        {
            return Ok(new DbLink.Login(_roleContext).CheckConnection(info));
        }

        [Route("Api/Login/Email")]
        public ActionResult CheckEmail(EmailCheck courriel)
        {
            return Ok(new DbLink.Login(_roleContext).EmailExisting(courriel.Email));
        }
    }
}
