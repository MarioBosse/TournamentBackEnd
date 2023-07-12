using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Roles
{
    [Table("rol_DisciplinesUsers")]
    public class DisciplineUser
    {
        public long IdDiscipline { get; set; }
        public long IdUser { get; set; }
    }
}
