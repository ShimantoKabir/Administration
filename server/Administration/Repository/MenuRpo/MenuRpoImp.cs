using System;
using System.Collections.Generic;
using System.Linq;
using Administration.Database;
using Administration.Models;

namespace Administration.Repository.MenuRpo
{
    public class MenuRpoImp : MenuRpo
    {

        private readonly AdministrationDBCtx dbCtx;

        public MenuRpoImp(AdministrationDBCtx dbCtx)
        {

            this.dbCtx = dbCtx;

        }

        public Response create(Request request)
        {
            
            Response response = new Response();

            dbCtx.Database.BeginTransaction();
            try
            {

                dbCtx.menus.Add(request.menu);
                dbCtx.SaveChanges();
                
                response.menu = request.menu;
                response.code = 200;
                response.msg = "Menu creation successful.";
                dbCtx.Database.CommitTransaction();

            }
            catch (Exception e)
            {

                response.msg = e.Message;    //  Block of code to handle errors
                response.code = 404;

            }

            return response;

        }

        public Response read()
        {
            
            Response response = new Response();
            response.menus = this.getNestedMenu(dbCtx.menus.ToList(),0);
            response.code = 200;
            response.msg = "Menu read successful.";
            return response;
            
        }

        public List<Menu> getNestedMenu(List<Menu> menus, int pId){

            List<Menu> nestedTreeStructure = new List<Menu>();
            int ln = menus.Count;

            for (int i = 0; i < ln; i++) 
            {
                
                Menu menu = menus[i];

                if(menu.parentOid == pId){

                    List<Menu> children = this.getNestedMenu(menus,menu.id);

                    if(children.Count > 0){
                        menu.children = children;
                    }

                    nestedTreeStructure.Add(menu);

                }

            }

            return nestedTreeStructure;

        }

    }
}