using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Users
{
    [Table("usr_Skills")]
    public class Skill
    {
        public long IdSkill { get; set; }
        public string Difficulty { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
