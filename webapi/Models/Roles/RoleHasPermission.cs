using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.UsersRoles
{
    [Table("rol_RoleHasPermissions")]
    public class RoleHasPermission
    {
        public Int64 RoleId { get; set; }
        public String ModelType { get; set; } = String.Empty;
        public Int64 ModelId { get; set; }
    }
}
