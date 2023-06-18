using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace webapi.Models.UsersRoles
{
    [Table("rol_Roles")]
    public class Role
    {
        public Int64 IdRole { get; set; }
        public String Name { get; set; } = String.Empty;
        public String GuardName { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
