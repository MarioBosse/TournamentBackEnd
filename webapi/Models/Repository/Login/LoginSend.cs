//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Repository.Login
// Description : Classe qui régis les valeurs transmit par l'application pour
//               valider les informations utilisé pour la connexion d'un
//               utilisateur. Dans ces classes, il y a deux (2) méthode qui peuvent
//               être utilisée. La première est l'envoie d'une addresse courriel
//               pour vérifier si cette adresse est existante ou non. La seconde,
//               est d'envoyer une adresse courriel avec un mot de passe pour
//               effectuer une oppération de connexion complète et ainsi valider le
//               lien entre l'application et le service de gestion de la base de
//               données.
//
//----------------------------------------------------------------------------------
namespace webapi.Models.Repository.Login
{
    public class LoginSend
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class EmailCheck
    {
        public string Email { get; set; } = string.Empty;
    }
}
