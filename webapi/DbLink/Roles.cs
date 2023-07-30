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
using webapi.Models.Database.Roles;
using webapi.Models.Repository.Token;
using webapi.Models.Repository.Roles;
using System.Data.Entity;

//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Définition de Class
// Nom : Roles
// Héritage : Aucun
//
//----------------------------------------------------------------------------------
namespace webapi.DbLink
{
    public class Roles
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
        // Nom : Roles
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
        public Roles(UserRoleContext roleContext, IConfiguration configuration)
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
        // Nom : AddRoles
        // Description : Fonction utlisé pour crééer un nouvelle utilisateur.
        // Paramètres : 
        //      User    userValue   Structure contenant toutes les données pour créer un
        //                          nouvelle utilisateur.
        // 
        //----------------------------------------------------------------------------------
        public Int64 AddRoles(Role rolesValue)
        {
            if (rolesValue == null || _roleContext == null || _roleContext.Roles == null) return 0;
            _roleContext.Roles.Add(rolesValue);
            _roleContext.SaveChanges();

            return GetId(rolesValue.Name, rolesValue.GuardName);
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
        // Type de retour : RoleBase    Retourne les informations sur les roles que le
        //                              client dispose.
        // Nom : GetInfos
        // Description : Retourne les roles que l'utilsateur actif dispose.
        // Paramètres : TokenCheck  Structure contenant les informations pour la validation
        //                          d'un compte et d'une connexion.
        // 
        //----------------------------------------------------------------------------------
        public RolesBase GetInfos(TokenCheck infos)
        {
            TokenConnexion tokenC = new ConnexionState(_roleContext, _configuration).GetConnexionState(infos);
            if (infos == null || infos.Email == null || _roleContext == null || _roleContext.Users == null || _roleContext.Roles == null) return new RolesBase() { TokenConnexion = tokenC };
            var roles = _roleContext.Users.Where(e => e.Email == infos.Email).FirstOrDefault();
            if (roles == null) return new RolesBase() { TokenConnexion = tokenC };

            return new RolesBase()
            {
                TokenConnexion = tokenC,
                Roles = GetAllRoles(roles.Roles)
            };
        }

        private List<RoleBase> GetAllRoles(uint roles)
        {
            List<RoleBase> ret = new List<RoleBase>();
            if(_roleContext == null || _roleContext.Roles == null) return ret;
            uint max = _roleContext.Roles.Max(e => e.Mask);
            do
            {
                if(roles >= max)
                {
                    Role? role = _roleContext.Roles.Where(e => e.Mask == max).FirstOrDefault();
                    if (role == null) continue;
                    ret.Add( new RoleBase() { Name = role.Name, GuardName = role.GuardName });
                    roles -= max;
                }
                max /= 2;
            } while (max >= 1);
            return ret;
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
        public Int64 GetMask(String email)
        {
            if (email == null || _roleContext == null || _roleContext.Users == null) return 0;
            var user = _roleContext.Users.Where(e => e.Email == email).FirstOrDefault();
            if (user == null) return 0;

            return user.IdUser;
        }
        public Int64 GetId(String name, String guard)
        {
            if (name == null || _roleContext == null || _roleContext.Roles == null) return 0;
            var role = _roleContext.Roles.Where(e => e.Name == name || e.GuardName == guard).FirstOrDefault();
            if (role == null) return 0;

            return role.IdRole;
        }
    }
}
