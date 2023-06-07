﻿using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.UsersRoles
{
    [Table("Disciplines")]
    public class Discipline
    {
        public Int64 Id { get; set; }
        public String Activity{ get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
