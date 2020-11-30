using Administration.Models;
using Microsoft.EntityFrameworkCore;

namespace Administration.Seed
{
    public static class UserInfoSeeder
    {
        public static void seedUserInfo(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserInfo>().HasData(
                new UserInfo{
                    id = 1,
                    oId = 1,
                    orgOid = 0,
                    userId= "developer",
                    userName="developer",
                    email="developer@mail.com",
                    password="3dacbce532ccd48f27fa62e993067b3c35f094f7",
                },
                new UserInfo{
                    id = 2,
                    oId = 2,
                    orgOid = 0,
                    userId= "qa",
                    userName="qa",
                    email="qa@mail.com",
                    password="d3c583412a36313ab5e24293924c39a36b842c56",
                },
                new UserInfo{
                    id = 3,
                    oId = 3,
                    orgOid = 0,
                    userId= "cto",
                    userName="cto",
                    email="cto@mail.com",
                    password="19f7ca240c1a90751ff47695616871db95411694",
                },
                new UserInfo{
                    id = 4,
                    oId = 4,
                    orgOid = 0,
                    userId= "ceo",
                    userName="ceo",
                    email="ceo@mail.com",
                    password="9d382342daac150ef51c8383dcf21ff57743b96d",
                }
            );

        }
    }
}