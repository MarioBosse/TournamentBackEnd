//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Messages
// Description : Classe qui régis les valeurs de retour pour toutes les appels d'API
//               effectués. L'objet retournée informe l'application du status de la
//               liaison entre celle-ci et les services offert qu'elle a besoin.
//
//----------------------------------------------------------------------------------
using webapi.Models.Repository.Token;

//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Définition de Class
// Nom : Message
// Héritage : Aucun
//
//----------------------------------------------------------------------------------
namespace webapi.Messages
{
    public class ApiResponse
    {
        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 16 Juillet 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : TokenConnexion
        // Nom : MessageConnexion
        // Description : Cette fonction retourne un objet MessageConnexion qui indique
        //               l'état de la connexion entre l'application Web et le gesitionnaire
        //               de service.
        // Paramètres : Bool    isConnected Valeur VRAI ou FAUX indiquant si l'application a
        //                                  une connexion active avec le gestionnaire de services.
        //              Int16   code        Valeur numérique indiqant le type d'erreur
        //                                  rencontré
        //              String  message     Description du message d'erreur
        // 
        //----------------------------------------------------------------------------------
        public TokenConnexion MessageConnexion(bool isConnected, Int16 code, String message)
        {
            return new TokenConnexion { IsConnected = isConnected,
                                        ConnexionCode = code,
                                        Message = message };
        }
    }
}
