using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Tournaments
{
    [Table("trn_Matchups")]
    public class Matchup
    {
        public Int64 IdMatchup { get; set; }
        public Int64 IdTournament { get; set; }
        public Int64 IdMatchupType { get; set; }
        public Int64 IdTournamentPhase { get; set; }
        public Int64 IdTeamVisitor { get; set; }
        public Int64 IdTeamLocal { get; set; }
        public Int16 ScoreVisitor { get; set; }
        public Int16 ScoreLocal { get; set; }

        public virtual Tournament Tournament { get; set; }
        public virtual MatchupType MatchupType { get; set; }
        public virtual TournamentPhaese TournamentPhaese { get; set; }
        public virtual Team TeamVisitor { get; set; }
        public virtual Team TeamLocal { get; set; }
    }
}
