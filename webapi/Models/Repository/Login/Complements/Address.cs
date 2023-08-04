//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Repository.Login.Complements
// Description : Classe qui régis les valeurs de retour pour l'adresse de résidence
//               d'un utilisateur.
//
//----------------------------------------------------------------------------------
namespace webapi.Models.Repository.Login.Complements
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : Address
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class Address
    {
        public String DoorNumber { get; set; } = String.Empty;
        public String StreetName { get; set; } = String.Empty;
        public String StreetName2 { get; set; } = String.Empty;
        public String AppNumber { get; set; } = String.Empty;
        public String Zipcode { get; set; } = String.Empty;
        public String City { get; set; } = String.Empty;
        public String State { get; set; } = String.Empty;
        public String Country { get; set; } = String.Empty;
    }
}
