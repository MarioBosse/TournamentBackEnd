using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Address
{
    [Table("adr_Provinces")]
    public class Province
    {
        public long IdProvince { get; set; }
        public string Name { get; set; } = string.Empty;
        public long IdCountry { get; set; }
    }
}
