using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Tournaments
{
    [Table("trn_TournamentPhases")]
    public class TournamentPhaese
    {
        public long IdTournamentPhase { get; set; }
        public long IdTournamentId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
