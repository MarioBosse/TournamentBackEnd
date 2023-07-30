using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace webapi.Models.Database.Roles
{
    [Table("rol_Roles")]
    public class Role
    {
        public long IdRole { get; set; }
        public string Name { get; set; } = string.Empty;
        public string GuardName { get; set; } = string.Empty;
        public UInt32 Mask { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateddAt { get; set; } = DateTime.Now;
    }
}
