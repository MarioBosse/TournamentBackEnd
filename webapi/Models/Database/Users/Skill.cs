//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Database.Users
// Description : Classe qui régis les informations requise pour effectuer la
//               création de la table 'usr_Skills' dans la base de données.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Users
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : Skill
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    [Table("usr_Skills")]
    public class Skill
    {
        public long IdSkill { get; set; }
        public string Difficulty { get; set; } = string.Empty;
        public bool IsActivated { get; set; } = false;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
