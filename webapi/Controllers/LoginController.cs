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
        private readonly UserRoleContext _roleContext;
        private readonly IConfiguration _configuration;

        public LoginController(UserRoleContext roleContext, IConfiguration configuration)
        {
            _roleContext = roleContext;
            _configuration = configuration;
        }
        // Donne la liste de tous les courriels enregistrés

        #region Api/Login/All
        [Route("All")]
        public ActionResult GetAll(TokenCheck token)
        {
            return Ok(new Login(_roleContext, _configuration).GetAlls(token));
        }
        #endregion
        #region Api/Login/CreateConnexion
        [Route("CreateConnexion")]
        public ActionResult CreateConnexion(LoginSend info)
        {
            return Ok(new DbLink.Login(_roleContext, _configuration).GetConnection(info));
        }
        #endregion
        #region Api/Login/IsValidConnexion
        [Route("IsValidConnexion")]
        public ActionResult IsValidConnection(TokenCheck info)
        {
            return Ok(new DbLink.Login(_roleContext, _configuration).IsConnexionValid(info));
        }
        #endregion
        #region Api/Login/Email
        [Route("Email")]
        public ActionResult CheckEmail(EmailCheck courriel)
        {
            return Ok(new DbLink.Login(_roleContext, _configuration).EmailExisting(courriel.Email));
        }
        #endregion
    }
}
