//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Boss� (GiMB)
// @2023 Tout droit r�serv�. Reproducion interdite
//
// Concepteur : Mario Boss�
// 16 Juillet 2023
//
// Nom : webapi.Models.Database.Address
// Description : Classe qui r�gis les informations pour effectuer la cr�ation de la
//               table 'adr_Address' dans la base de donn�es.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Address
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Boss�
    // 16 Juillet 2023
    //
    // D�finition de Class
    // Nom : Address
    // H�ritage : Aucun
    //
    //----------------------------------------------------------------------------------
    [Table("adr_Address")]
    public class Address
    {
        public long IdAddress { get; set; }
        public string DoorNumber { get; set; } = string.Empty;
        public string StreetName { get; set; } = string.Empty;
        public string StreetName2 { get; set; } = string.Empty;
        public string AppNumber { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty;
        public long? IdCity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateddAt { get; set; } = DateTime.Now;
    }
}
