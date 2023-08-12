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
//               table 'rol_ModelHasRoles' dans la base de données.
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
    // Nom : ModelHasRoles
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    [Table("rol_ModelHasRoles")]
    public class ModelHasRoles
    {
        public long IdModelHasRoles { get; set; }
        public string ModelType { get; set; } = string.Empty;
        public long IdModel { get; set; }
        public bool IsActivated { get; set; } = false;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
