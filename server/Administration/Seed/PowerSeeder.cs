using Administration.Models;
using Microsoft.EntityFrameworkCore;

namespace Administration.Seed
{
    public static class PowerSeeder
    {
        
        public static void seedPower(this ModelBuilder modelBuilder){
            
            modelBuilder.Entity<Power>().HasData(
                new Power{
                    id=1,
                    powerName = "General",
                    powerValue = 5,
                },
                new Power{
                    id=2,
                    powerName = "Colonel",
                    powerValue = 4,
                },
                new Power{
                    id=3,
                    powerName = "Major",
                    powerValue = 3,
                },
                new Power{
                    id=4,
                    powerName = "Captain",
                    powerValue = 2,
                },
                new Power{
                    id=5,
                    powerName = "Lieutenant",
                    powerValue = 1,
                }
            );

        }

    }
}