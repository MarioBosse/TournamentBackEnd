using System.ComponentModel.DataAnnotations.Schema;
using webapi.Models.Database.Users;

namespace webapi.Models.Database.Roles
{
    [Table("rol_DisciplinesUsers")]
    public class DisciplineUser
    {
        public long IdDiscipline { get; set; }
        public long IdUser { get; set; }
    }
}
