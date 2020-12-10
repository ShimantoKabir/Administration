using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administration.Models
{
    /*
     * Q1: What is opAccess?
     * A1: opAccess is the user CRUD operation access like, will a user can act
     * create operation, read operation or delete operation. Data sample will be
     * like [c], [u], [d], [cu], [cd] or [crud] 
     */
    public class UserConfiguration
    {

        public int id { get; set; }
        public int orgOid { get; set; }
        public int roleOid { get; set; }
        public int projectOid { get; set; }
        public int userInfoOid { get; set; }
        public string? opAccess { get; set; }
        public string? ip { get; set; }
        public int? modifiedBy { get; set; }
        
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime createdAt { get; set; }

    }
}