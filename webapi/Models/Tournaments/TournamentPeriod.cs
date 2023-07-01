using Org.BouncyCastle.Security;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Tournaments
{
    [Table("trn_TournamentPeriods")]
    public class TournamentPeriod
    {
        public Int64 IdTournamentPeriod { get; set; }
        public Int64 IdTournament { get; set; }
        public String Name { get; set; } = String.Empty;
    }
}
