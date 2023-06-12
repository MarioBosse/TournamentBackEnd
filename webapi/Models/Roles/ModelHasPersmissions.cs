using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.UsersRoles
{
    [Table("rol_ModelHasPermissions")]
    public class ModelHasPersmissions
    {
        public Int64 IdPermission { get; set; }
        public String Model_Type { get; set; } = String.Empty;
        public Int64 IdModel { get; set; }
    }
}
