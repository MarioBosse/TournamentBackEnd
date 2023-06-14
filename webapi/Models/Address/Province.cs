using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Address
{
    [Table("adr_Provinces")]
    public class Province
    {
        public Int64 IdProvince { get; set; }
        public String Name { get; set; }
        public Int64 IdCountry { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<City> Citys { get; set;}
        public Province()
        {
            Citys = new HashSet<City>();
        }
    }
}
