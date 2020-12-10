using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administration.Models
{

    /*
    * Q1: Why orgOid can be null?
    * A1: In first registration a user will have no organization.
    * or sometimes when a user switch their organization user will have
    * no organization.
    */
    public class UserInfo
    {
        
        public int id { get; set; }
        public int oId { get; set; }
        public int? orgOid { get; set; }
        public string? userId { get; set; }
        public string? userName { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
        public string? socialLoginId { get; set; }
        public string? imgUrl { get; set; }
        public string? ip { get; set; }
        public int? modifiedBy { get; set; }
        
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime createdAt { get; set; }

    }

}