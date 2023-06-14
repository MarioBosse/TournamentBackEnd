using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Address
{
    [Table("adr_Address")]
    public class Address
    {
        public long IdAddress { get; set; }
        public string? DoorNumber { get; set; }
        public string? StreetName { get; set; }
        public string? StreetName2 { get; set; }
        public string? AppNumber { get; set; }
        public Int64 IdCity { get; set; }
        public virtual City? City { get; set; }
    }
}
