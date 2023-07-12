using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Context;
using webapi.Models.Repository.Token;

namespace webapi.Controllers
{
    [ApiController]
    [Route("Api/")]
    public class UtilisateursController : Controller
    {
        private IConfiguration _configuration { get; set; }
        private UserRoleContext _userRoleContext { get; set; }
        public UtilisateursController(UserRoleContext userRoleContext, IConfiguration configuration)
        {
            _userRoleContext = userRoleContext;
            _configuration = configuration;
        }

        [Route("Address/Check")]
        public ActionResult CheckAddress(TokenCheck tokenCheck)
        {
            return Ok();
        }
        [Route("Address/Add")]
        public ActionResult AddAddress(TokenCheck tokenCheck)
        {
            return Ok();
        }
        [Route("Address/Modify")]
        public ActionResult ModfyAddress(TokenCheck tokenCheck)
        {
            return Ok();
        }
        [Route("Address/Delete")]
        public ActionResult DeleteAddress(TokenCheck tokenCheck)
        {
            return Ok();
        }
        [Route("Address/Get")]
        public ActionResult GetAddress(TokenCheck tokenCheck)
        {
            return Ok();
        }
        [Route("User/Check")]
        public ActionResult CheckUser(TokenCheck tokenCheck)
        {
            return Ok();
        }
        [Route("User/Add")]
        public ActionResult AddUser(TokenCheck tokenCheck)
        {
            return Ok();
        }
        [Route("User/Modify")]
        public ActionResult ModifyUser(TokenCheck tokenCheck)
        {
            return Ok();
        }
        [Route("User/Delete")]
        public ActionResult DeleteUser(TokenCheck tokenCheck)
        {
            return Ok();
        }
        [Route("User/Get")]
        public ActionResult GetUser(TokenCheck tokenCheck)
        {
            return Ok();
        }
    }
}
