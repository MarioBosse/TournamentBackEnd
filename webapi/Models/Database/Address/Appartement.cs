//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Database.Address
// Description : Classe qui régis les informations pour effectuer la création de la
//               table 'adr_Appartement' dans la base de données. Cette classe peut
//               aussi être utilisé pour enregistrer toutes informations
//               complémentaires en lien avec une adresse d'utilisateur.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Address
{
    [Table("adr_appartment")]
    public class Appartement
    {
        public Int64 IdAppartmet { get; set; }
        public Int64 IdAddress { get; set; }
        public String Information { get; set; } = String.Empty;
    }
}
