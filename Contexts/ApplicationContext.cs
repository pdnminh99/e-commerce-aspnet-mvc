using Microsoft.EntityFrameworkCore;
using EcommerceApp2259.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace EcommerceApp2259.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }

        public DbSet<ProductImage> ProductImage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImage>()
                .HasOne<Product>(i => i.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(i => i.ProductId);
        }

    }
}