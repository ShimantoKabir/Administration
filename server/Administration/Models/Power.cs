using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administration.Models
{
    /*
     * org oid with null will be pre data when an organization first registration
     */
    public class Power
    {
        
        public int id { get; set; }
        public int? orgOid { get; set; }
        [Required]
        public string powerName { get; set; }
        public int powerValue { get; set; }
        public string? ip { get; set; }
        public int? modifiedBy { get; set; }
        
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime createdAt { get; set; }

    }
    
}