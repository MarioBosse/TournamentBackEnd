using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Tournaments
{
    [Table("trn_Teams")]
    public class Team
    {
        public long IdTeam { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateddAt { get; set; } = DateTime.Now;
    }
}
