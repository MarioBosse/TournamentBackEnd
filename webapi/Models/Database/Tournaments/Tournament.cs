using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Tournaments
{
    [Table("trn_Tournaments")]
    public class Tournament
    {
        public long IdTournament { get; set; }
        public long IdTournamentType { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte[]? Picture { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateddAt { get; set; } = DateTime.Now;
    }
}
