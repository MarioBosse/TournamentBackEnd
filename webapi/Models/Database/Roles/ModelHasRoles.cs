using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Roles
{
    [Table("rol_ModelHasRoles")]
    public class ModelHasRoles
    {
        public long IdModelHasRoles { get; set; }
        public string ModelType { get; set; } = string.Empty;
        public long IdModel { get; set; }
    }
}
