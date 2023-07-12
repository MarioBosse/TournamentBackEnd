using Org.BouncyCastle.Security;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Tournaments
{
    [Table("trn_TournamentPeriods")]
    public class TournamentPeriod
    {
        public long IdTournamentPeriod { get; set; }
        public long IdTournament { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateddAt { get; set; } = DateTime.Now;
    }
}
