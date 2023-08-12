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
//               table 'rol_Roles' dans la base de données.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace webapi.Models.Database.Roles
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : Role
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    [Table("rol_Roles")]
    public class Role
    {
        public long IdRole { get; set; }
        public string Name { get; set; } = string.Empty;
        public string GuardName { get; set; } = string.Empty;
        public UInt32 Mask { get; set; } = 0;
        public bool IsActivated { get; set; } = false;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
