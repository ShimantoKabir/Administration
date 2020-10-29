using Administration.Models;
using Microsoft.EntityFrameworkCore;

namespace Administration.Database
{
    public class AdministrationDBCtx : DbContext
    {

        public AdministrationDBCtx(DbContextOptions<AdministrationDBCtx> opt) : base(opt){}
        
        public DbSet<UserInfo> userInfos { get; set; }
        public DbSet<Menu> menus { get; set; }
        public DbSet<Organization> organizations { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<RestrictedMenu> restrictedMenus { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<UserConfiguration> userConfigurations { get; set; }

    }
}