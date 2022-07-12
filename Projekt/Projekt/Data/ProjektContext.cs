using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projekt.Models;

namespace Projekt.Data
{
    public class ProjektContext : DbContext
    {
        public ProjektContext (DbContextOptions<ProjektContext> options)
            : base(options)
        {
        }

        public DbSet<Projekt.Models.Part> Part { get; set; }
        public DbSet<Projekt.Models.Category> Category { get; set; }
        //public DbSet<Projekt.Models.Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>().ToTable("Part");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Role>().ToTable("Role");

            //string adminRoleName = "admin";
            //string userRoleName = "user";

            //string adminPassword = "123456";

            //// добавляем роли
            //Role adminRole = new Role { id = 1, Name = adminRoleName };
            //Role userRole = new Role { id = 2, Name = userRoleName };
            //SiteUser adminUser = new SiteUser { id = 1, password = adminPassword, RoleId = adminRole.id };

            //modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            //modelBuilder.Entity<SiteUser>().HasData(new SiteUser[] { adminUser });
            //base.OnModelCreating(modelBuilder);
        }
    }
}
