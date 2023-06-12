using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Tournaments
{
    [Table("trn_Rosters")]
    public class Roster
    {
        public Int64 Id { get; set; }
        public Int64 TeamId { get; set; }
        public Int64 UserId { get; set;}
    }
}
