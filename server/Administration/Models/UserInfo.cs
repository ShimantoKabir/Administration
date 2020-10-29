using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Administration.Models
{

    public class UserInfo
    {

        public int id { get; set; }
        public int orgId { get; set; }
        public String userId { get; set; }
        public String userName { get; set; }

        [Required]
        public String email { get; set; }

        [Required]
        public String password { get; set; }
        public String socialLoginId { get; set; }
        public String opAccess { get; set; }
        public String imgUrl { get; set; }
        public String ip { get; set; }
        public int? modifiedBy { get; set; }
        public DateTime createdAt { get; set; }

    }

}