using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Administration.Models
{

    public class UserInfo
    {
        // Q1: Why orgOid can be null?
        // A1: In first registration a user will have no organization.
        // or sometimes when a user switch their organization user will have
        // no organization.

        public int id { get; set; }
        public int oId { get; set; }
        public int? orgOid { get; set; }
        public String userId { get; set; }
        public String userName { get; set; }

        [Required]
        public String email { get; set; }

        [Required]
        public String password { get; set; }
        public String socialLoginId { get; set; }
        public String imgUrl { get; set; }
        public String ip { get; set; }
        public int? modifiedBy { get; set; }
        public DateTime createdAt { get; set; }

    }

}