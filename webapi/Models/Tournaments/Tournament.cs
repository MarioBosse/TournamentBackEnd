using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Tournaments
{
    [Table("trn_Tournaments")]
    public class Tournament
    {
        public Int64 IdTournament { get; set; }
        public Int64 IdTournamentType { get; set; }
        public String Name { get; set; }

        public virtual TournamentType TournamentType { get; set; }
    }
}
