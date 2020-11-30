using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administration.Models
{
    public class Menu
    {

        // Q1: Why orgOid is can be null?
        // A1: Cause a menu with null orgOid is the default value. Whenever a new
        // org registered those default value need to be auto insert.

        // Q2: Is there any menu is for app owner administration menu
        // A2: Yes, a menu with 0 orgOid is for app owner administration menu

        public int id { get; set; }
        public int oId { get; set; }
        public int? orgOid { get; set; }

        [Required]
        public int projectOid { get; set; }

        [Required]
        public String menuName { get; set; }

        public String tooltip { get; set; }
        public String component { get; set; }
        public String path { get; set; }

        [Required]
        public int parentOid { get; set; }

        [Required]
        public int power { get; set; }
        public String ip { get; set; }
        public int? modifiedBy { get; set; }
        public DateTime createdAt { get; set; }

        [NotMapped]
        public String text { get; set; }
        [NotMapped]
        public Menu data { get; set; }
        [NotMapped]
        public Menu state { get; set; }
        [NotMapped]
        public Boolean expendend { get; set; }
        [NotMapped]
        public List<Menu> children { get; set; }

    }

}