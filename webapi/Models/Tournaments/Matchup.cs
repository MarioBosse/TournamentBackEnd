using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Tournaments
{
    [Table("trn_Matchups")]
    public class Matchup
    {
        public Int64 Id { get; set; }
        public Int64 TournamentId { get; set; }
        public Int64 MatchupTypeId { get; set; }
        public Int64 TournamentPhaseId { get; set; }
        public Int64 TeamVisitorId { get; set; }
        public Int64 TeamLocalId { get; set; }
        public Int16 ScoreVisitor { get; set; }
        public Int16 ScoreLocal { get; set; }
    }
}
