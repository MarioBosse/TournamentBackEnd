//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Repository.Roles
// Description : Classe qui régis les valeurs à manipuler soit par l'application,
//               soit par le service, afin d'effectuer toutes les oppérations en
//               lien avec les rôles de l'utilisateur.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
using webapi.Models.Repository.Token;

namespace webapi.Models.Repository.Roles
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : GetInfos
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class GetInfos
    {
        public String Email { get; set; } = String.Empty;
        public String Token { get; set; } = String.Empty;
    }

    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : RoleBase
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class RoleBase
    {
        public long IdUser { get; set; }
        public string Name { get; set; } = string.Empty;
        public string GuardName { get; set; } = string.Empty;
    }

    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : RolesBase
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class RolesBase
    {
        public List<RoleBase> Roles { get; set; } = new List<RoleBase>();

        public TokenConnexion TokenConnexion { get; set; }
    }

    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : Add
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class Add
    {
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : Delete
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class Delete
    {
        public bool Deleted { get; set; } = false;
        public TokenConnexion Validation { get; set; } = new TokenConnexion();
    }
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : Definition
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class Definition
    {
        public TokenCheck Validation { get; set; } = new TokenCheck();
    }
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : ReadRole
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class ReadRole
    {
        public long IdUser { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Guard { get; set; } = string.Empty;
        public uint Mask { get; set; } = 0;
    }
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : RoleModify
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class RoleModify
    {
        public TokenCheck tokenCheck { get; set; } = new TokenCheck();
        public RoleBase Origin { get; set; } = new RoleBase();
    }
}
