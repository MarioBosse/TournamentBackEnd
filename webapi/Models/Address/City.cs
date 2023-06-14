using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Address
{
    [Table("adr_Citys")]
    public class City
    {
        public Int64 IdCity { get; set; }
        public String Name { get; set; }
        public Int64 IdProvince { get; set; }
        public virtual Province Province { get; set; }
    }
}
