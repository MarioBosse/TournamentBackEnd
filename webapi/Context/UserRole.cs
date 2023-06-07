using MySql.Data.EntityFramework;
using System.Data.Entity;
using webapi.Models.UsersRoles;

namespace webapi.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class UserRole : DbContext
    {
        private static readonly MySqlEFConfiguration? _configuration;
        private String? connectionString = String.Empty;

        public DbSet<User>? Users { get; private set; }
        public UserRole(IConfiguration config)
        {
            connectionString = config.GetValue<String>("MySqlConnection:User");
        }
    }
}
