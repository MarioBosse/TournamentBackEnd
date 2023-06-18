using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Users
{
    [Table("usr_Users")]
    public class User
    {
        public long IdUser { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string ProfilePhoto { get; set; } = string.Empty;
        public bool IsActivated { get; set; } = false;
        public string PasswordResetCode { get; set; } = string.Empty;
        public string ActivationCode { get; set; } = string.Empty;
        public string RememberToken { get; set; } = string.Empty;
        public Int64 IdAddress { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual Address.Address Adresse { get; set; }
    }
}
