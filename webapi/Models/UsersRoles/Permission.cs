using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.UsersRoles
{
    [Table("Permissions")]
    public class Permission
    {
        public Int64 ID { get; set; }
        public String Name { get; set; } = String.Empty;
        public String GuardName { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
