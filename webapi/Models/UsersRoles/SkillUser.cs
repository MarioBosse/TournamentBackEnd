using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.UsersRoles
{
    [Table("SkillsUser")]
    public class SkillUser
    {
        public Int64 IdDiscipline { get; set; }
        public Int64 IdUser { get; set; }
    }
}
