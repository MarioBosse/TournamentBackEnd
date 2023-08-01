//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Database.Roles
// Description : Classe qui régis les informations pour effectuer la création de la
//               table 'rol_ModelHasPermissions' dans la base de données.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Roles
{
    [Table("rol_ModelHasPermissions")]
    public class ModelHasPersmissions
    {
        public long IdPermission { get; set; }
        public string Model_Type { get; set; } = string.Empty;
        public long IdModel { get; set; }
    }
}
