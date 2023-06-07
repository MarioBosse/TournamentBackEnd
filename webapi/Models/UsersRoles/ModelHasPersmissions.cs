using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.UsersRoles
{
    [Table("Model_Has_Permissions")]
    public class ModelHasPersmissions
    {
        public Int64 IdPermission { get; set; }
        public String Model_Type { get; set; } = String.Empty;
        public Int64 IdModel { get; set; }
    }
}
