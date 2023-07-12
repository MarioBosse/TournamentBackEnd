using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Address
{
    [Table("adr_appartment")]
    public class Appartement
    {
        public Int64 IdAppartmet { get; set; }
        public Int64 IdAddress { get; set; }
        public String Information { get; set; } = String.Empty;
    }
}
