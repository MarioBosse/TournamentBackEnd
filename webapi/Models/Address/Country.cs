using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Address
{
    [Table("adr_Countries")]
    public class Country
    {
        public Int64 IdCountry { get; set; }
        public String Name { get; set; } = String.Empty;
    }
}
