//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Repository.Tournament.TypesRetour
// Description : Classes qui régissent les valeurs de retour pour l'utilisation de
//               la table TournamentTypes.
//
//----------------------------------------------------------------------------------
using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Tournament.TypesRetour
{
    public class AddType
    {
        public Int64 Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }

    public class DeleteType
    {
        public bool DeleteDone { get; set; } = false;
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }
}
