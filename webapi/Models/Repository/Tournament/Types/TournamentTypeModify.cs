//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Repository.Tournament.Types
// Description : Classe qui régis les valeurs lors de la modification des type de
//               tournoi par le biais de la table TounamentType.
//
//----------------------------------------------------------------------------------
using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Tournament.Types
{
    public class TournamentTypeModify
    {
        public String Origin { get; set; } = String.Empty;
        public String Destination { get; set; } = String.Empty;
        public TokenCheck TokenCheck { get; set; } = new TokenCheck();
    }
}
