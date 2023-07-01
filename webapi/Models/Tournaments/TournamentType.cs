using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Tournaments
{
    [Table("trn_TournamentTypes")]
    public class TournamentType
    {
        public Int64 IdTournamentType { get; set; }
        public String Name { get; set; } = String.Empty;
    }
}
