using Microsoft.AspNetCore.Mvc;
using webapi.Context;
using webapi.Models.Users;

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

        [Route("[controler]/All")]
        public List<String> GetAlls()
        {
            List<User> usr = new DbLink.Login(_roleContext).GetAlls();
            List<String> result = new List<String>();

            foreach(var user in usr)
            {
                result.Add(user.ProfilePhoto);
            }

            return result;
        }
    }
}
