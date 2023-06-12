using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Tournaments
{
    [Table("trn_Players")]
    public class MatchupType
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
    }
}
