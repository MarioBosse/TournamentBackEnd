//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Database.Camping
// Description : Classe qui régis les informations pour effectuer la création de la
//               table 'cmp_Terrain' dans la base de données.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Camping
{
    [Table("cmp_Terrain")]
    public class Terrain
    {
        public long IdTerrain { get; set; }
        public string Name { get; set; } = string.Empty;
        public long IdAddress { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateddAt { get; set; } = DateTime.Now;
    }
}
