using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.UsersRoles
{
    [Table("rol_ModelHasRoles")]
    public class ModelHasRoles
    {
        public Int64 IdModelHasRoles { get; set; }
        public String ModelType { get; set; } = String.Empty;
        public Int64 IdModel { get; set; }  
    }
}
