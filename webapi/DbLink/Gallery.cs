using webapi.Context;

namespace webapi.DbLink
{
    public class Gallery
    {
        private UserRoleContext _roleContext;
        private IConfiguration _configuration;

        public Gallery(UserRoleContext roleContext, IConfiguration configuration)
        {
            _roleContext = roleContext;
            _configuration = configuration;
        }
    }
}
