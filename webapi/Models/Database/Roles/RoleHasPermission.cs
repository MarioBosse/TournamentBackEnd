using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Roles
{
    [Table("rol_RoleHasPermissions")]
    public class RoleHasPermission
    {
        public long IdRolePermission { get; set; }
        public string ModelType { get; set; } = string.Empty;
        public long IdModel { get; set; }
    }
}
