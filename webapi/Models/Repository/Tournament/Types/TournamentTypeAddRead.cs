//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Repository.Tournament.Types
// Description : Classe qui régis les valeurs de retour pour tous les ajouts et
//               suppressions de données dans la table TournamentType.
//
//----------------------------------------------------------------------------------
using webapi.Models.Database.Tournaments;
using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Tournament.Types
{
    public class TournamentTypeAddRead
    {
        public TokenCheck tokenCheck { get; set; } = new TokenCheck();
        public String Description { get; set; } = String.Empty;
    }

    public class TournamentTypeDelete
    {
        public TokenCheck tokenCheck { get; set; } = new TokenCheck();
        public TournamentType tournamentType { get; set; } = new TournamentType();
    }
}
