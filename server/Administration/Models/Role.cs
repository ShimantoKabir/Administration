using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administration.Models
{
    /*
    * Q1. should role need to tag with project id?
    * A1: I think not, cause role can be tagged with any org or any project
    * to know a role tagging, we need to go UserConfiguration table, in this
    * table we can know a role is tagged by which org and which project.
    * 
    * Q2: Why orgOid is can be null?
    * A2: Cause a role with null orgOid is the default value. Whenever a new
    * org registered those default value need to be auto insert.
    * 
    * Q3: Is there any role is for developer, QA engineer, CTO or CEO
    * A3: Yes, a role with 0 orgOid is for developer, QA engineer, CTO or CEO.
    */
    public class Role
    {
        
        public int id { get; set; }
        public int oId { get; set; }
        public int? orgOid { get; set; } 
        
        [Required]
        public int powerValue { get; set; }
        
        [Required]
        public string? roleName { get; set; }
        public string? ip { get; set; }
        public int? modifiedBy { get; set; }
        
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime createdAt { get; set; }
        
    }
}