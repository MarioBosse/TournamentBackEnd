using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.UsersRoles
{
    [Table("Discipline_User")]
    public class DisciplineUser
    {
        public Int64 IdDiscipline { get; set; }
        public Int64 IdUser { get; set; }
    }
}
