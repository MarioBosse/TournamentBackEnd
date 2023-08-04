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
//               table 'rol_Disciplines' dans la base de données.
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
    // Nom : Discipline
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    [Table("rol_Disciplines")]
    public class Discipline
    {
        public long IdDiscipline { get; set; }
        public string Activity { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
