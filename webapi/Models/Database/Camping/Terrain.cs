using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Camping
{
    [Table("cmp_Terrain")]
    public class Terrain
    {
        public long IdTerrain { get; set; }
        public string Name { get; set; } = string.Empty;
        public long IdAddress { get; set; }
    }
}
