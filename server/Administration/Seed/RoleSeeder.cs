using Administration.Models;
using Microsoft.EntityFrameworkCore;

namespace Administration.Seed
{
    public static class RoleSeeder
    {
        public static void seedRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    id = 1,
                    oId = 1,
                    roleName = "CTO",
                    powerValue = 4
                },
                new Role
                {
                    id = 1,
                    oId = 1,
                    roleName = "Developer",
                    powerValue = 3
                },
                new Role
                {
                    id = 1,
                    oId = 1,
                    roleName = "CEO",
                    powerValue = 2
                },
                new Role
                {
                    id = 1,
                    oId = 1,
                    roleName = "QA",
                    powerValue = 1
                }
            );
        }
    }
}