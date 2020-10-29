using System.Collections.Generic;

namespace Administration.Models
{
    public class Request
    {
        public UserInfo userInfo { get; set; }
        public List<Menu> menus { get; set; }
        public Menu menu { get; set; }
        
    }
}