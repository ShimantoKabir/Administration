using System.ComponentModel.DataAnnotations;

namespace Administration.Models
{
    public class RestrictedMenu
    {
        public int id { get; set; }

        [Required]
        public int menuOid { get; set; }

        [Required]
        public int userInfoOid { get; set; }
    }
}