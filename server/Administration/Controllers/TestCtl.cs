using System;
using System.Threading.Tasks;
using Administration.Models;
using Administration.Services;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Administration.Controllers
{

    [Route("/api/test")]
    [ApiController]
    public class TestCtl : ControllerBase
    {

        [HttpGet("app")]
        public ActionResult<Response> testApp()
        {
            var response = new Response {code = 200, msg = "App running....!"};
            return response;

        }

        [HttpPost("email")]
        public ActionResult<Response> testEmail(EmailRequest emailRequest)
        {
            var mailer = new Mailer();
            BackgroundJob.Enqueue(() => mailer.send(emailRequest));
            Response response = new Response {code = 200, msg = "App running....!"};
            return response;

        }
        
    }

}