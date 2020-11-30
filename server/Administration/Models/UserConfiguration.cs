using System;

namespace Administration.Models
{

    public class UserConfiguration
    {
        
        // Q1: What is opAccess?
        // A1: opAccess is the user CRUD operation access like, will a user can act
        // create operation, read operaion or delete operation. Data sample will be
        // like [c], [cr], [cru] or [crud]

        public int id { get; set; }
        public int orgOid { get; set; }
        public int roleOid { get; set; }
        public int projectOid { get; set; }
        public int userInfoOid { get; set; }
        public String opAccess { get; set; }
        public String ip { get; set; }
        public int? modifiedBy { get; set; }
        public DateTime createdAt { get; set; }

    }

}