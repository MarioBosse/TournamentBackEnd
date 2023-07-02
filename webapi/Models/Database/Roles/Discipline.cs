using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Roles
{
    [Table("rol_Disciplines")]
    public class Discipline
    {
        public long IdDiscipline { get; set; }
        public string Activity { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
