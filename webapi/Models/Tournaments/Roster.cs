using System.ComponentModel.DataAnnotations.Schema;
using webapi.Models.Users;

namespace webapi.Models.Tournaments
{
    [Table("trn_Rosters")]
    public class Roster
    {
        public Int64 IdRoster { get; set; }
        public Int64 IdTeam { get; set; }
        public Int64 IdUser { get; set;}

        public virtual Team Team { get; set; }
        public virtual User User { get; set; }
    }
}
