using System;
using System.ComponentModel.DataAnnotations;

namespace Administration.Models
{
    public class Project
    {
        public int id { get; set; }

        [Required]
        public String projectName { get; set; }
        public String ip { get; set; }
        public int? modifiedBy { get; set; }
        public DateTime createdAt { get; set; }

    }
    
}