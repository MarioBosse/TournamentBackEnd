using System.ComponentModel.DataAnnotations.Schema;
using webapi.Models.Users;

namespace webapi.Models.Tournaments
{
    [Table("trn_Players")]
    public class Player
    {
        public Int64 IdPlayer { get; set; }
        public Int64 IdTeam { get; set; }
        public Int64 IdUser { get; set; }
    }
}
