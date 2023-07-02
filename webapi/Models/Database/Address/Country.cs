using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Address
{
    [Table("adr_Countries")]
    public class Country
    {
        public long IdCountry { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
