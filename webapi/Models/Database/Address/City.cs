using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Address
{
    [Table("adr_Citys")]
    public class City
    {
        public long IdCity { get; set; }
        public string Name { get; set; } = string.Empty;
        public long IdProvince { get; set; }
    }
}
