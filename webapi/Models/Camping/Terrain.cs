using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Camping
{
    [Table("cmp_Terrain")]
    public class Terrain
    {
        public Int64 IdTerrain { get; set; }
        public String Name { get; set; } = String.Empty;
        public Int64 IdAddress { get; set; }
    }
}
