using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Address
{
    [Table("adr_Provinces")]
    public class Province
    {
        public Int64 IdProvince { get; set; }
        public String Name { get; set; } = String.Empty;
        public Int64 IdCountry { get; set; }
    }
}
