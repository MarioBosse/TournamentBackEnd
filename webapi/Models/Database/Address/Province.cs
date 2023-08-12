﻿//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : webapi.Models.Database.Address
// Description : Classe qui régis les informations pour effectuer la création de la
//               table 'adr_Provinces' dans la base de données.
//
//----------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Database.Address
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : Province
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    [Table("adr_Provinces")]
    public class Province
    {
        public long IdProvince { get; set; }
        public string Name { get; set; } = string.Empty;
        public long IdCountry { get; set; }
        public bool IsActivated { get; set; } = false;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
