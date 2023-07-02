using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Tournaments
{
    [Table("trn_MatchupTypes")]
    public class MatchupType
    {
        public long IdMatcupType { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
