using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administration.Models
{
    public class Organization
    {
        public int id { get; set; }
        public int oId { get; set; }
        [Required]
        public string? orgName { get; set; }
        public string? ip { get; set; }
        public int? modifiedBy { get; set; }
        
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime createdAt { get; set; }

    }
    
}