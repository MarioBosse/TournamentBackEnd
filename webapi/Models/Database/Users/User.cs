//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Boss� (GiMB)
// @2023 Tout droit r�serv�. Reproducion interdite
//
// Concepteur : Mario Boss�
// 16 Juillet 2023
//
// Nom : webapi.Models.Database.Users
// Description : Classe qui r�gis les informations pour cr�er la table 'usr_Users'
//               dans la base de donn�es.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Users
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Boss�
    // 16 Juillet 2023
    //
    // D�finition de Class
    // Nom : User
    // H�ritage : Aucun
    //
    //----------------------------------------------------------------------------------
    [Table("usr_Users")]
    public class User
    {
        public long IdUser { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public UInt32 Roles { get; set; } = 0;
        public DateTime? Birthdate { get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;
        public String ProfilePhoto { get; set; } = String.Empty;
        public bool IsActivated { get; set; } = false;
        public string? PasswordResetCode { get; set; } = string.Empty;
        public string? ActivationCode { get; set; } = string.Empty;
        public string? RememberToken { get; set; } = string.Empty;
        public long? IdAddress { get; set; } = 0;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
