//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.DbLink
// Description : Cette classe effectue le lien entre les controleurs et les différents
//               DbContext lié à l'interprétation et a l'utilisation des données de
//               la base de donnée en lien avec les utilisateurs. Celle-ci effectue
//               tous les appels vers la base de données ainsi que l'interprétation
//               de ces données avant d'être retourné vers l'application pour être
//               affiché à l'écran.
//
//----------------------------------------------------------------------------------
using webapi.Context;
using webapi.Models.Database.Users;
using webapi.Models.Repository.Token;
using webapi.Models.Repository.Users;

//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Définition de Class
// Nom : Users
// Héritage : Aucun
//
//----------------------------------------------------------------------------------
namespace webapi.DbLink
{
    public class Users
    {
        private UserRoleContext _roleContext { get; set; }
        private IConfiguration _configuration { get; set; }

        //----------------------------------------------------------------------------------
        //
        // Gestion Informatique Mario Bossé (GiMB)
        // @2023 Tout droit réservé. Reproducion interdite
        //
        // Concepteur : Mario Bossé
        // 16 Juillet 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : Constructeur
        // Nom : Users
        // Description : Fonction contructeur qui crée les bases de la classe.
        // Paramètres :
        //      UserRoleContext     roleContext     Variable contenant la liaison avec la
        //                                          base de données pouvant être intérogé
        //                                          pour récupérer, modifier, sauvegarder
        //                                          et supprimer des données.
        //      IConfiguration      configuration   Variable contenant une référence pour
        //                                          accèder aux données de configuration de
        //                                          l'application.
        // 
        //----------------------------------------------------------------------------------
        public Users(UserRoleContext roleContext, IConfiguration configuration)
        {
            _roleContext = roleContext;
            _configuration = configuration;
        }

        //----------------------------------------------------------------------------------
        //
        // Gestion Informatique Mario Bossé (GiMB)
        // @2023 Tout droit réservé. Reproducion interdite
        //
        // Concepteur : Mario Bossé
        // 16 Juillet 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : Int64   Retourne la valeud UserId créé lors de l'enregistrement
        //                          des nouvelles données.
        // Nom : AddUser
        // Description : Fonction utlisé pour crééer un nouvelle utilisateur.
        // Paramètres : 
        //      User    userValue   Structure contenant toutes les données pour créer un
        //                          nouvelle utilisateur.
        // 
        //----------------------------------------------------------------------------------
        public Int64 AddUser(User usersValue)
        {
            if (usersValue == null || _roleContext == null || _roleContext.Users == null) return 0;
            _roleContext.Users.Add(usersValue);
            _roleContext.SaveChanges();

            return GetId(usersValue.Email);
        }

        //----------------------------------------------------------------------------------
        //
        // Gestion Informatique Mario Bossé (GiMB)
        // @2023 Tout droit réservé. Reproducion interdite
        //
        // Concepteur : Mario Bossé
        // 16 Juillet 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : UserBase    Retourne les informations, non confidentiel ou
        //                              sensible, de l'usager demandé.
        // Nom : GetInfos
        // Description : Retourne les informations de l'utilsateur actif, une fois les
        //               informations du jeton validé.
        // Paramètres : TokenCheck  Structure contenant les informations pour la validation
        //                          d'un compte et d'une connexion.
        // 
        //----------------------------------------------------------------------------------
        public UserBase GetInfos(TokenCheck infos)
        {
            TokenConnexion tokenC = new ConnexionState(_roleContext, _configuration).GetConnexionState(infos);
            if (_roleContext == null || _roleContext.Users == null) return new UserBase() { TokenConnexion = new Models.Repository.Token.TokenConnexion() { } };
            User? user = _roleContext.Users.Where(e => e.Email == infos.Email).FirstOrDefault();
            if (user == null || user.IdAddress == null) return new UserBase() { TokenConnexion = tokenC };

            return new UserBase()
            {
                TokenConnexion = tokenC,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = new Roles(_roleContext, _configuration).GetInfos(infos).Roles,
                Email = user.Email,
                Gender = user.Gender,
                Birthdate = user.Birthdate,
                ProfilePhoto = user.ProfilePhoto,
                IsActivated = user.IsActivated,
                IdAddress = user.IdAddress,
                userAddress = new Address(_roleContext).Get(user.IdAddress)
            };
        }

        //----------------------------------------------------------------------------------
        //
        // Gestion Informatique Mario Bossé (GiMB)
        // @2023 Tout droit réservé. Reproducion interdite
        //
        // Concepteur : Mario Bossé
        // 16 Juillet 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : Int64   
        // Nom : GetId
        // Description : Fonction retournant l'identifiant d'un utilisateur a partir d'une
        //               addresse courriel. Cette adresse doit être existante dans la base
        //               de données sinon, la value sera 0.
        // Paramètres : String  Addresse courriel a vérifier.
        // 
        //----------------------------------------------------------------------------------
        public Int64 GetId(String email)
        {
            if (email == null || _roleContext == null || _roleContext.Users == null) return 0;
            var user = _roleContext.Users.Where(e => e.Email == email).FirstOrDefault();
            if(user == null) return 0;

            return user.IdUser;
        }
    }
}
