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
        [Route("Address/Add")]
        [Route("Address/Modify")]
        [Route("Address/Delete")]
        [Route("Address/Get")]
        [Route("User/")]
        [Route("User/")]
        [Route("User/")]
        [Route("User/")]
        [Route("User/")]
        public ActionResult UserXX(TokenCheck tokenCheck)
        {
            return Ok();
        }
    }
}
