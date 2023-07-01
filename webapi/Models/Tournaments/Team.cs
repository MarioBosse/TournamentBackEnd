﻿using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.Tournaments
{
    [Table("trn_Teams")]
    public class Team
    {
        public Int64 IdTeam { get; set; }
        public String Name { get; set; } = String.Empty;
    }
}
