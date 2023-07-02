using Microsoft.AspNetCore.Mvc;
using webapi.Context;

namespace webapi.Controllers
{
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly UserRoleContext _roleContext;

        public GalleryController(UserRoleContext roleContext)
        {
            _roleContext = roleContext;
        }

        [Route("Api/Gallery/All")]
        public ActionResult GetAllTournaments()
        {
            return Ok();
        }
    }
}
