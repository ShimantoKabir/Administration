using Administration.Models;
using Administration.Seed;
using Microsoft.EntityFrameworkCore;

namespace Administration.Database
{
    /*
    *
    * Two thins you need  to do before update migration
    * 1. replace datetime(6) to datetime
    * 2. createAt column should be like that bellow
    * [createdAt = table.Column<DateTime>(defaultValueSql: "CURRENT_TIMESTAMP")]
    */
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
        public DbSet<Power> powers {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.seedUserInfo();
            modelBuilder.seedPower();
            modelBuilder.seedRole();
            modelBuilder.seedProject();
            modelBuilder.seedMenu();
        }

    }
}