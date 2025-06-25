
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using productManager.Models.Entities;

namespace productManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<Product> Products { get; set; }

        public DbSet<Types> types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                    .HasOne(p => p.Product)
                    .WithMany(t => t.Types)
                    .HasForeignkey<Types>(p => p.Types);
 

            modelBuilder.Entity<Types>().HasData(
                new Types { Gender = "Male" },
                new Types { Gender = "Female" }
            );
        }
    }
}
