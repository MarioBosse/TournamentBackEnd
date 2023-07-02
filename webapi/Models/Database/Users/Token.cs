using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Users
{
    [Table("usr_token")]
    public class Token
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public string SecurityToken { get; set; } = string.Empty;
    }
}
