using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Tournaments
{
    [Table("trn_Teams")]
    public class Team
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
    }
}
