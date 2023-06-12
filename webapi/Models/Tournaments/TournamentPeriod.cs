using Org.BouncyCastle.Security;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Tournaments
{
    [Table("trn_TournamentPeriods")]
    public class TournamentPeriod
    {
        public Int64 Id { get; set; }
        public Int64 TournamentId { get; set; }
        public String Name { get; set; }
    }
}
