﻿//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Database.Building
// Description : Classe qui régis l'importation d'un groupe de données vers la base
//               de données.
//
//----------------------------------------------------------------------------------
namespace webapi.Models.Database.Building
{
    public class TransitRoles
    {
        public string Name { get; set; } = string.Empty;
        public string GuardName { get; set; } = string.Empty;
        public UInt32 Mask { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
