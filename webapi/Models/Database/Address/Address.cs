using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Address
{
    [Table("adr_Address")]
    public class Address
    {
        public long IdAddress { get; set; }
        public string DoorNumber { get; set; } = string.Empty;
        public string StreetName { get; set; } = string.Empty;
        public string StreetName2 { get; set; } = string.Empty;
        public string AppNumber { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty;
        public long? IdCity { get; set; }
    }
}
