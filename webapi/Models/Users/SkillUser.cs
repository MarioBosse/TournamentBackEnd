using System.ComponentModel.DataAnnotations.Schema;
using webapi.Models.UsersRoles;

namespace webapi.Models.Users
{
    [Table("usr_SkillsUsers")]
    public class SkillUser
    {
        public long IdDiscipline { get; set; }
        public long IdUser { get; set; }

        public virtual Discipline Discipline { get; set; }
        public virtual User User { get; set; }
    }
}
