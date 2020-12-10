using Administration.Models;
using Microsoft.EntityFrameworkCore;

namespace Administration.Seed
{
    public static class ProjectSeeder
    {
        public static void seedProject(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    id = 1,
                    oId = 1,
                    projectName = "Administration"
                },
                new Project
                {
                    id = 2,
                    oId = 2,
                    projectName = "Meal Management System"
                },
                new Project
                {
                    id = 3,
                    oId = 3,
                    projectName = "Personal AIS"
                },
                new Project
                {
                    id = 4,
                    oId = 4,
                    projectName = "Remote Office Management System"
                }
            );
        }
    }
}