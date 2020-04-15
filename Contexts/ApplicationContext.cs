using Microsoft.EntityFrameworkCore;
using EcommerceApp2259.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace EcommerceApp2259.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<ProductImage> ProductImage { get; set; }

        public DbSet<ProductDetail> ProductDetail { get; set; }

        public DbSet<Brand> Brand { get; set; }
        
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductImage)
                .WithOne(i => i.Product);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductDetail)
                .WithOne(d => d.Product);

            // modelBuilder.Entity<Category>()
            //     .HasMany(c => c.Products)
            //     .WithOne(p => p.Category);
            //
            // modelBuilder.Entity<Brand>()
            //     .HasMany(b => b.Products)
            //     .WithOne(p => p.Brand);
        }
    }
}