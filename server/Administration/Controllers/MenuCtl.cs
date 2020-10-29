using Administration.Models;
using Administration.Repository.MenuRpo;
using Administration.Repository.UserInfoRpo;
using Microsoft.AspNetCore.Mvc;

namespace Administration.Controllers
{
    [Route("/api/menus")]
    [ApiController]
    public  class MenuCtl
    {

        public readonly MenuRpo menuRpo;

        public MenuCtl(MenuRpo menuRpo)
        {

            this.menuRpo = menuRpo;
            
        }

        [HttpGet("test")]
        public ActionResult<Response> test()
        {

            Response response = new Response();
            response.code = 200;
            response.msg = "Menu controller smoke test OK!";
            return response;

        }

        [HttpPost]
        public ActionResult<Response> create(Request request)
        {

            Response response = menuRpo.create(request);
            response.userInfo = request.userInfo;
            return response;

        }

        [HttpGet]
        public ActionResult<Response> read()
        {

            Response response = menuRpo.read();
            // response.code = 200;
            // response.menus = menuRpo.read();
            // response.msg = "Menu controller smoke test OK!";
            return response;


        }

    }
}