//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Database.Tournaments
// Description : Classe qui régis les informations pour effectuer la création de la
//               table 'trn_TournamentPeriods' dans la base de données.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Tournaments
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : TournamentPeriod
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    [Table("trn_TournamentPeriods")]
    public class TournamentPeriod
    {
        public long IdTournamentPeriod { get; set; }
        public long IdTournament { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateddAt { get; set; } = DateTime.Now;
    }
}
