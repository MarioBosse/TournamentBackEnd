using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Context;

namespace webapi.Controllers
{
    public class GalleryController : Controller
    {
        private readonly UserRoleContext _roleContext;
        public GalleryController(UserRoleContext roleContext)
        {
            _roleContext = roleContext;
        }
    }
}
