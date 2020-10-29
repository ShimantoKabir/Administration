using System;
using System.ComponentModel.DataAnnotations;

namespace Administration.Models
{
    public class Role
    {
        public int id { get; set; }

        [Required]
        public int power { get; set; }

        [Required]
        public String roleName { get; set; }
        public String ip { get; set; }
        public int? modifiedBy { get; set; }
        public DateTime createdAt { get; set; }

    }
}