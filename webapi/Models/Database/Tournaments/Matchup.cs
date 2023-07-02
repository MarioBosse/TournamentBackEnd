using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Tournaments
{
    [Table("trn_Matchups")]
    public class Matchup
    {
        public long IdMatchup { get; set; }
        public long IdTournament { get; set; }
        public long IdMatchupType { get; set; }
        public long IdTournamentPhase { get; set; }
        public long IdTeamVisitor { get; set; }
        public long IdTeamLocal { get; set; }
        public short ScoreVisitor { get; set; }
        public short ScoreLocal { get; set; }
    }
}
