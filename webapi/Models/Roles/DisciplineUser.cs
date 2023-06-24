using System.ComponentModel.DataAnnotations.Schema;
using webapi.Models.Users;

namespace webapi.Models.UsersRoles
{
    [Table("rol_DisciplinesUsers")]
    public class DisciplineUser
    {
        public Int64 IdDiscipline { get; set; }
        public Int64 IdUser { get; set; }
    }
}
