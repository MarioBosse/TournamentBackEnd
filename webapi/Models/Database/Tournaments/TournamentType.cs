using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Tournaments
{
    [Table("trn_TournamentTypes")]
    public class TournamentType
    {
        public long IdTournamentType { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
