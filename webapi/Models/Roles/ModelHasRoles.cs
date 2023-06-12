using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.UsersRoles
{
    [Table("rol_ModelHasRoles")]
    public class ModelHasRoles
    {
        public Int64 Id { get; set; }
        public String modelType { get; set; }
        public Int64 ModelId { get; set; }  
    }
}
