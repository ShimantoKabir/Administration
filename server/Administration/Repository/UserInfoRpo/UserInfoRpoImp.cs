using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Administration.Database;
using Administration.Models;
using Administration.Services;
using Microsoft.EntityFrameworkCore;

namespace Administration.Repository.UserInfoRpo
{
    public class UserInfoRpoImp : UserInfoRpo
    {

        private readonly AdministrationDBCtx dbCtx;

        private readonly IMailer iMailer;

        public UserInfoRpoImp(AdministrationDBCtx dbCtx, IMailer iMailer)
        {

            this.dbCtx = dbCtx;
            this.iMailer = iMailer;

        }

        public Response createUserInfo(Request request)
        {
            
            Response response = new Response();

            dbCtx.Database.BeginTransaction();
            try
            {

                dbCtx.userInfos.Add(request.userInfo);
                dbCtx.SaveChanges();
                iMailer.SendEmailAsync(request.userInfo.email, "User Authentication.", "Hey, man.");
                response.code = 200;
                response.msg = "User info creation successful.";
                dbCtx.Database.CommitTransaction();

            }
            catch (Exception e)
            {

                response.msg = e.Message;    //  Block of code to handle errors
                response.code = 404;

            }

            return response;

        }

        public Response getUserInfoById(int id)
        {
            Response response = new Response();
            UserInfo userInfo = dbCtx.userInfos.FirstOrDefault(u => u.id == id);
            Console.Write(userInfo);
            response.userInfo = userInfo;
            response.msg = "User info fetch successful.";
            return response;

        }

        public Response getUserInfos()
        {

            Response response = new Response();

            dbCtx.Database.BeginTransaction();
            try
            {

                response.userInfos = dbCtx.userInfos.ToList();
                response.code = 200;
                response.msg = "User info list fetched successfull.";
                dbCtx.Database.CommitTransaction();

            }
            catch (Exception e)
            {
                response.msg = e.Message;    //  Block of code to handle errors
                response.code = 404;
            }


            return response;

        }

    }

}