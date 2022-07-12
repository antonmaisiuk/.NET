using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NET_PS_8.Models;

namespace NET_PS_8.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext (DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public DbSet<NET_PS_8.Models.Product> Product { get; set; }
        public DbSet<NET_PS_8.Models.Category> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");

            //modelBuilder.Entity<Category>()
            //.HasMany(c => c.Products)
            //.WithOne(e => e.Category)
            //.OnDelete(DeleteBehavior.SetNull);
        }
    }
}
