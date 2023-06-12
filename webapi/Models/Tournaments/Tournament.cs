using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Tournaments
{
    [Table("trn_Tournaments")]
    public class Tournament
    {
        public Int64 Id { get; set; }
        public Int64 TournamentType { get; set; }
        public String Name { get; set; }
    }
}
