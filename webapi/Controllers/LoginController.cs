using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using webapi.Context;
using webapi.Models;

namespace webapi.Controllers
{

    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserRoleContext _roleContext;
        private readonly IConfiguration _configuration;

        public LoginController(UserRoleContext roleContext, IConfiguration configuration)
        {
            _roleContext = roleContext;
            _configuration = configuration;
        }
        // Donne la liste de tous les courriels enregistrés
        [Route("Api/Login/All")]
        public ActionResult GetAll()
        {
            return Ok(new DbLink.Login(_roleContext, _configuration).GetAlls());
        }
        [Route("Api/Login/Check")]
        public ActionResult Check(LoginSend info)
        {
            return Ok(new DbLink.Login(_roleContext, _configuration).CheckConnection(info));
        }

        [Route("Api/Login/Email")]
        public ActionResult CheckEmail(EmailCheck courriel)
        {
            return Ok(new DbLink.Login(_roleContext, _configuration).EmailExisting(courriel.Email));
        }
    }
}
