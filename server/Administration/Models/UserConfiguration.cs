using System;

namespace Administration.Models
{
    public class UserConfiguration
    {
        
        public int id { get; set; }
        public int? orgId { get; set; }
        public int? roleId { get; set; }
        public int? projectId { get; set; }
        public String ip { get; set; }
        public int? modifiedBy { get; set; }
        public DateTime createdAt { get; set; }

    }
}