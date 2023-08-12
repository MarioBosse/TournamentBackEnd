//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Database.Building
// Description : Classe qui régis l'importation d'un groupe de données vers la base
//               de données.
//
//----------------------------------------------------------------------------------
namespace webapi.Models.Database.Building
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : TransitUserValue
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class TransitUserValue
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UInt32 Roles { get; set; } = 0;
        public string Gender { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public String DoorNumber { get; set; } = String.Empty;
        public String StreetName { get;set; } = String.Empty;
        public String[]? Infos { get; set; }
        public String ProfilePicture { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
