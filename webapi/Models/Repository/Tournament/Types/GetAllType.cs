//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Repository.Tournament.Types
// Description : Classe qui régis les valeurs de retour la récupération de totes
//               les informations en lien avec la table TournamentType.
//
//----------------------------------------------------------------------------------
using webapi.Models.Database.Tournaments;
using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Tournament.Types
{
    public class GetAllType
    {
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
        public TournamentType[] TournamentTypes { get; set; }
    }
}
