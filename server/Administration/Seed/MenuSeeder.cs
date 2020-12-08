using Administration.Models;
using Microsoft.EntityFrameworkCore;

namespace Administration.Seed
{
    public static class MenuSeeder
    {
        public static void seedMenu(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().HasData(
                new Menu
                {
                    id = 1,
                    oId = 1,
                    orgOid = 0,
                    projectOid = 1,
                    menuName = "Administration",
                    tooltip = "Administration project root menu.",
                    parentOid = 0
                },
                    new Menu
                    {
                        id = 2,
                        oId = 2,
                        orgOid = 0,
                        projectOid = 1,
                        menuName = "User",
                        tooltip = "User menu root.",
                        path = "/user",
                        component = "/User",
                        parentOid = 1
                    },
                        new Menu
                        {
                            id = 3,
                            oId = 3,
                            orgOid = 0,
                            projectOid = 1,
                            menuName = "Manage",
                            path = "/user/manage",
                            component = "/user/Manage",
                            tooltip = "Create, delete, update user.",
                            parentOid = 2
                        },
                    new Menu
                    {
                        id = 4,
                        oId = 4,
                        orgOid = 0,
                        projectOid = 1,
                        menuName = "Menu",
                        path = "/menu",
                        component = "/Menu",
                        tooltip = "Menu root.",
                        parentOid = 1
                    },
                        new Menu
                        {
                            id = 5,
                            oId = 5,
                            orgOid = 0,
                            projectOid = 1,
                            menuName = "Manage",
                            path = "/menu/manage",
                            component = "/menu/Manage",
                            tooltip = "Create, update, delete menu.",
                            parentOid = 4
                        },
                        new Menu
                        {
                            id = 5,
                            oId = 5,
                            orgOid = 0,
                            projectOid = 1,
                            menuName = "Role Wise Permission",
                            path = "/menu/role-wise-permission",
                            component = "/menu/RoleWisePermission",
                            tooltip = "Give permission by role.",
                            parentOid = 4
                        },
                        new Menu
                        {
                            id = 6,
                            oId = 6,
                            orgOid = 0,
                            projectOid = 1,
                            menuName = "User Wise Permission",
                            path = "/menu/user-wise-permission",
                            component = "/menu/UserWisePermission",
                            tooltip = "Give permission by user.",
                            parentOid = 4
                        }
            );
        }
    }
}