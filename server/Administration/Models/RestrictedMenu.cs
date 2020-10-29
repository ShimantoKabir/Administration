using System.ComponentModel.DataAnnotations;

namespace Administration.Models
{
    public class RestrictedMenu
    {
        public int id { get; set; }

        [Required]
        public int menuId { get; set; }

        [Required]
        public int userId { get; set; }
    }
}