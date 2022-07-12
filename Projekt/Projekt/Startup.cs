using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Projekt.Models;
using Projekt.Data;

namespace Projekt
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


            //services.AddTransient<TimeService>();

            services.AddDbContext<ProjektContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ProjektContext")));
            services.AddAuthentication("CookieAuthentication")
            .AddCookie("CookieAuthentication", config =>
            {
                config.Cookie.HttpOnly = true;
                config.Cookie.SecurePolicy = CookieSecurePolicy.None;
                config.Cookie.Name = "UserLoginCookie";
                config.LoginPath = "/Login/UserLogin";
                config.Cookie.SameSite = SameSiteMode.Strict;
            });

            services.AddRazorPages();
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/admin");
            });


            

            //string connection = "Server=(localdb)\\mssqllocaldb;Database=rolesappdb;Trusted_Connection=True;";
            //services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            //services.AddDbContext<ApplicationContext>(options =>
            //       options.UseSqlServer(Configuration.GetConnectionString("ProjektContext")));

            //services.AddAuthentication("CookieAuthentication")
            //.AddCookie("CookieAuthentication", config =>
            //{
            //    config.Cookie.HttpOnly = true;
            //    config.Cookie.SecurePolicy = CookieSecurePolicy.None;
            //    config.Cookie.Name = "UserLoginCookie";
            //    config.LoginPath = "/Login/UserLogin";
            //    config.Cookie.SameSite = SameSiteMode.Strict;
            //});

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {
                    
            //        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            //        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            //    });

            //services.AddRazorPages(options =>
            //{
            //    options.Conventions.AuthorizeFolder("/admin");
            //});

            //services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseMiddleware<TimerMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {                
                endpoints.MapRazorPages();
            });
        }
    }
}
