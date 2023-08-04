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
    // Nom : TransitAdressesValue
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class TransitAdresseValue
    {
        public string NamePlace { get; set; } = string.Empty;
        public string DoorNumber { get; set; } = string.Empty;
        public string StreetName { get; set; } = string.Empty;
        public string StreetName2 { get; set; } = string.Empty;
        public string AppNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty;
        public string Pays { get; set; } = string.Empty;
    }
}
