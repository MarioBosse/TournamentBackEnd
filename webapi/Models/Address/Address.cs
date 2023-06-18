using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Address
{
    [Table("adr_Address")]
    public class Address
    {
        public long IdAddress { get; set; }
        public String DoorNumber { get; set; } = String.Empty;
        public String StreetName { get; set; } = String.Empty;
        public String StreetName2 { get; set; } = String.Empty;
        public String AppNumber { get; set; } = String.Empty;
        public String Zipcode { get; set; } = String.Empty; 
        public Int64? IdCity { get; set; }
    }
}
