﻿
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using productManager.Controllers;
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

        public DbSet<Store> Store { get; set; }
        
        public DbSet<StorePrdt> StorePrdt { get; set; }

        public DbSet<User> User{ get; set; } 

        public DbSet<Purchase> Purchases { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd(); // auto-increment


            modelBuilder.Entity<Product>()
                    .HasOne(p => p.Types)
                    .WithMany(t => t.Products)
                    .HasForeignKey(p => p.TypeId);

            //many to many start
            modelBuilder.Entity<StorePrdt>()
                .HasOne(sp => sp.Product)
                .WithMany(p => p.StorePrdts)
                .HasForeignKey(sp => sp.PrdtId);

            modelBuilder.Entity<StorePrdt>()
                .HasOne(sp => sp.Store)
                .WithMany(s => s.StorePrdt)
                .HasForeignKey(sp => sp.StoreId);
            //many to many end


            //Many to many join start
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Product)
                .WithMany(pur => pur.Purchases)
                .HasForeignKey(p => p.prdtId);

            modelBuilder.Entity<Purchase>()
                .HasOne(u => u.User)
                .WithMany(pur => pur.Purchase)
                .HasForeignKey(u => u.CusId);
            //many to many join end

            modelBuilder.Entity<Types>().HasData(
                new Types { Id = 1, Gender = "Male" },
                new Types { Id = 2,  Gender = "Female" }
            );
        }
    }
}
