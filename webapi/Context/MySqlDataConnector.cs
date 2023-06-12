using MySql.Data.MySqlClient;

namespace webapi.Context
{
    public class MySqlDataConnector
    {

        public MySqlDataConnector(IConfiguration _configuration)
        {

            using (MySqlConnection conn = new MySqlConnection(""))
            {
            }
        }
    }
}
