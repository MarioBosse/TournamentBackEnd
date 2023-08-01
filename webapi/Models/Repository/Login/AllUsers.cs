//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Repository.Login
// Description : Classe qui régis les valeurs de retour pour un utilisateur.
//               Cette classe ne contient aucun élément pouvant être définie comme
//               senssible.
//
//----------------------------------------------------------------------------------
namespace webapi.Models.Repository.Login
{
    public class AllUsers
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime? Birthdate { get; set; }
        public String ProfilePhoto { get; set; } = String.Empty;
        public bool IsActivated { get; set; } = false;
        public Complements.Address? Address { get; set; } = null;
    }
}
