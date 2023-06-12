using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Tournaments
{
    [Table("trn_Players")]
    public class Player
    {
        public Int64 PlayerId { get; set; }
        public Int64 TeamId { get; set; }
    }
}
