using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace webapi.Models.UsersRoles
{
    [Table("Roles")]
    public class Role
    {
        public Int64 Id { get; set; }
        public String Name { get; set; } = String.Empty;
        public String GuardName { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
