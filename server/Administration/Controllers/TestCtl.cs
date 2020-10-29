using System;
using System.Threading.Tasks;
using Administration.Models;
using Administration.Services;
using Microsoft.AspNetCore.Mvc;

namespace Administration.Controllers
{

    [Route("/api/test")]
    [ApiController]
    public class TestCtl : ControllerBase
    {

        private readonly IMailer iMailer;
        
        public TestCtl(IMailer iMailer){
            this.iMailer = iMailer;
        }
        
        [HttpGet]
        public ActionResult<Response> test()
        {

            iMailer.SendEmailAsync("kabir3483@gmail.com", "Weather Report", "Detailed Weather Report");
            Response response = new Response();
            response.code = 200;
            response.msg = "App running....!";
            return response;

        }

    }

}