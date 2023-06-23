using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Users
{
    [Table("usr_token")]
    public class Token
    {
        public Int64 Id { get; set; }
        public Int64 IdUser { get; set; }
        public String SecurityToken { get; set; } = String.Empty;
    }
}
