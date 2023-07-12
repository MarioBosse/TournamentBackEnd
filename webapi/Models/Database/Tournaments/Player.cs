using System.ComponentModel.DataAnnotations.Schema;
using webapi.Models.Database.Users;

namespace webapi.Models.Database.Tournaments
{
    [Table("trn_Players")]
    public class Player
    {
        public long IdPlayer { get; set; }
        public long IdTeam { get; set; }
        public long IdUser { get; set; }
    }
}
