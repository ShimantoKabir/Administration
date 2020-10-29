using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administration.Models
{
    public class Menu
    {

        public int id { get; set; }
        public int? orgId { get; set; }

        [Required]
        public int projectId { get; set; }

        [Required]
        public String menuName { get; set; }

        public String tooltip { get; set; }
        public String component { get; set; }
        public String path { get; set; }

        [Required]
        public int parentId { get; set; }

        [Required]
        public int power { get; set; }
        public String ip { get; set; }
        public int? modifiedBy { get; set; }
        public DateTime createdAt { get; set; }

        [NotMapped]
        public List<Menu> children { get; set; }

    }

}