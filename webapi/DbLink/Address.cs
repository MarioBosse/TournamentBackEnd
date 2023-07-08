using System.Collections.Generic;
using System.Data.Entity.Core;
using webapi.Context;
using webapi.Models.Database.Tournaments;
using webapi.Models.Database.Users;
using webapi.Models.Repository.Token;
using webapi.Models.Repository.Users;
namespace webapi.DbLink
{
    public class Address
    {
        private UserRoleContext _roleContext { get; set; }
        private IConfiguration _configuration { get; set; }
        #region Constructeur
        public Address(UserRoleContext context, IConfiguration configuration)
        {
            _roleContext = context;
            _configuration = configuration;
        }
        #endregion
        #region Address
        #endregion
    }
}
