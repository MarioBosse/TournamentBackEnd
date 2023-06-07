using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.UsersRoles
{
    [Table("Users")]
    public class User
    {
        public Int64 Id { get; set; }
        public String FirstName { get; set; } = String.Empty;
        public String LastName { get; set; } = String.Empty;
        [Required]
        public String Email { get; set; } = String.Empty;
        public String Gender { get; set; } = String.Empty;
        [Required]
        public String Password { get; set; } = String.Empty;
        public String ProfilePhoto { get; set; } = String.Empty;
        public Boolean IsActivated { get; set; } = false;
        public String PasswordResetCode { get; set; } = String.Empty;
        public String ActivationCode { get; set; } = String.Empty;
        public String RememberToken { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
