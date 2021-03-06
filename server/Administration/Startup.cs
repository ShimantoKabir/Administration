using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Administration.Database;
using Administration.Models;
using Administration.Repository;
using Administration.Repository.MenuRpo;
using Administration.Repository.UserInfoRpo;
using Administration.Services;
using Hangfire;
using Hangfire.MySql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Administration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AdministrationDBCtx>(
                options => options.UseMySql(
                    Configuration.GetConnectionString("administration")
                ));

            services.AddHangfire(configuration => {
                configuration.UseStorage(
                    new MySqlStorage(
                        Configuration.GetConnectionString("hangfire"),
                        new MySqlStorageOptions
                        {
                            TablesPrefix = "Hangfire"
                        }
                    )
                );
            });
            
            services.AddControllers();
            services.AddTransient<UserInfoRpo, UserInfoRpoImp>();
            services.AddTransient<MenuRpo, MenuRpoImp>();
            
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseHangfireDashboard();
            app.UseHangfireServer();
            
        }
    }
}