using System;
using System.ComponentModel.DataAnnotations;

namespace Administration.Models
{
    public class Organization
    {
        public int id { get; set; }
        public int oId { get; set; }
        [Required]
        public String orgName { get; set; }
        public String ip { get; set; }
        public int? modifiedBy { get; set; }
        public DateTime createdAt { get; set; }

    }
    
}