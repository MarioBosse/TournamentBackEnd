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
    public class TransAddress
    {
        public string doorNumber { get; set; }
        public string streetName { get; set; }
        public string streetName2 { get; set; }
        public string appartment { get; set; }
        public string zipcode { get; set; }
        public long city { get; set; }

        public TransAddress(string door, string street, string street2, string appNumber, string zip, long ville)
        {
            doorNumber = door;
            streetName = street;
            streetName2 = street2;
            appartment = appNumber;
            zipcode = zip;
            city = ville;
        }
    }
}
