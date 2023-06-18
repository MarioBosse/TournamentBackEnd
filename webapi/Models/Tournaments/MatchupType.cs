using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Tournaments
{
    [Table("trn_MatchupTypes")]
    public class MatchupType
    {
        public Int64 IdMatcupType { get; set; }
        public String Name { get; set; }
    }
}
