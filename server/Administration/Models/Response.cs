using System.Collections.Generic;

namespace Administration.Models
{
    public class Response
    {
        public List<UserInfo> userInfos {get; set;}
        public List<Menu> menus { get; set; }
        public UserInfo userInfo { get; set; }
        public Menu menu { get; set; }
        public int code { get; set; } = 200;
        public string msg { get; set; } = null;
        
    }
}