//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Repository.Token
// Description : Classe qui régis les valeurs de retour la demande de validation
//               du jeton de connexnio.
//
//----------------------------------------------------------------------------------
namespace webapi.Models.Repository.Token
{
    public class TokenValidation
    {
        public bool IsValid { get; set; }
        public TokenConnexion TokenConnexion { get; set; } = new TokenConnexion();
    }
}
