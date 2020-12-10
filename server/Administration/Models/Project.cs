using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administration.Models
{
    public class Project
    {
        public int id { get; set; }
        public int oId { get; set; }
        
        [Required]
        public string? projectName { get; set; }
        public string? ip { get; set; }
        public int? modifiedBy { get; set; }
        
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime createdAt { get; set; }

    }
    
}