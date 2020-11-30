using System;
using System.ComponentModel.DataAnnotations;

namespace Administration.Models
{
    public class Power
    {
        public int id { get; set; }
        public int? orgOid { get; set; } // org oid with null will be pre data when an organization first registration
        [Required]
        public String powerName { get; set; }
        public int powerValue { get; set; }
        public String ip { get; set; }
        public int? modifiedBy { get; set; }
        public DateTime createdAt { get; set; }

    }
    
}