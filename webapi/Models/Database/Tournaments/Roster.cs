using System.ComponentModel.DataAnnotations.Schema;
using webapi.Models.Database.Users;

namespace webapi.Models.Database.Tournaments
{
    [Table("trn_Rosters")]
    public class Roster
    {
        public long IdRoster { get; set; }
        public long IdTeam { get; set; }
        public long IdUser { get; set; }
    }
}
