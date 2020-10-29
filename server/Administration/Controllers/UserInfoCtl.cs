using System.Collections.Generic;
using System.Threading.Tasks;
using Administration.Models;
using Administration.Repository;
using Administration.Repository.UserInfoRpo;
using Microsoft.AspNetCore.Mvc;

namespace Administration.Controllers
{
    [Route("/api/userinfos")]
    [ApiController]
    public class UserInfoCtl : ControllerBase
    {

        public readonly UserInfoRpo userInfoRpo;
        
        public UserInfoCtl(UserInfoRpo userInfoRpo)
        {

            this.userInfoRpo = userInfoRpo;
            
        }

        [HttpGet]
        public ActionResult<Response> getUserInfos()
        {
            Response response = userInfoRpo.getUserInfos();
            return Ok(response);

        }

        [HttpGet("{id}")]
        public ActionResult<Response> getUserInfoById(int id)
        {

            Response response = userInfoRpo.getUserInfoById(id);
            return Ok(response);

        }

        [HttpPost]
        public ActionResult<Response> createUserInfo(Request request)
        {

            Response response = userInfoRpo.createUserInfo(request);
            response.userInfo = request.userInfo;
            return Ok(response);

        }

    }

}