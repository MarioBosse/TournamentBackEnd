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
    // Nom : TransAddress
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class TransAddress
    {
        public string doorNumber { get; set; }
        public string streetName { get; set; }
        public string streetName2 { get; set; }
        public string appartment { get; set; }
        public string zipcode { get; set; }
        public long city { get; set; }

        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 16 Juillet 2023
        //
        // Fonction Constructeur
        // Héritage : Aucun
        // Niveau d'acces : Public
        // Base d'enregistrement : Aucun
        // Type de retour : Aucun
        // Nom : TransAddress
        // Description : Fonction contructeur qui effectue la création d'un objet TransAddress
        // Paramètres :     String  door        Numéro de porte
        //                  String  street      Nom de la rue
        //                  String  street2     Informations complémentaire de l'adresse
        //                  String  appNumber   Numéro d'appatement par défaut de l'adresse (si applicable)
        //                  String  zip         Code postal
        //                  Long    ville       Numéro d'identification de l'adresse
        //
        //----------------------------------------------------------------------------------
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
