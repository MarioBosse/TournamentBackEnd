using MySql.Data.MySqlClient;

namespace webapi.Context
{
    public class MySqlDataConnector
    {
        //private UserRoleContext _roleContext;
        public MySqlDataConnector(IConfiguration _configuration)
        {
            //_roleContext = new UserRoleContext(connection);

            using (MySqlConnection conn = new MySqlConnection(""))
            {
            }
        }
        public MySqlDataConnector(UserRoleContext userRoleContext)
        {
        }
    }
}
