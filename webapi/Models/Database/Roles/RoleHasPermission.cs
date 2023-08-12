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
//               table 'rol_RoleHasPermissions' dans la base de données.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Roles
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : RoleHasPermissions
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    [Table("rol_RoleHasPermissions")]
    public class RoleHasPermission
    {
        public long IdRolePermission { get; set; }
        public string ModelType { get; set; } = string.Empty;
        public long IdModel { get; set; }
        public bool IsActivated { get; set; } = false;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
