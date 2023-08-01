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
//               table 'trn_Matchups' dans la base de données.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Tournaments
{
    [Table("trn_Matchups")]
    public class Matchup
    {
        public long IdMatchup { get; set; }
        public long IdTournament { get; set; }
        public long IdMatchupType { get; set; }
        public long IdTournamentPhase { get; set; }
        public long IdTeamVisitor { get; set; }
        public long IdTeamLocal { get; set; }
        public short ScoreVisitor { get; set; }
        public short ScoreLocal { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateddAt { get; set; } = DateTime.Now;
    }
}
