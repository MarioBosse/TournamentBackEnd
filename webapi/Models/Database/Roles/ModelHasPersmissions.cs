using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Roles
{
    [Table("rol_ModelHasPermissions")]
    public class ModelHasPersmissions
    {
        public long IdPermission { get; set; }
        public string Model_Type { get; set; } = string.Empty;
        public long IdModel { get; set; }
    }
}
