using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Tournaments
{
    [Table("trn_TournamentPhases")]
    public class TournamentPhaese
    {
        public Int64 IdTournamentPhase { get; set; }
        public Int64 IdTournamentId { get; set; }
        public String Name { get; set; } = String.Empty;
    }
}
