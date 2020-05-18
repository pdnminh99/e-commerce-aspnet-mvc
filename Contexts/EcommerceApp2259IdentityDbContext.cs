using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EcommerceApp2259.Models;

namespace EcommerceApp2259.Contexts
{
    public class EcommerceApp2259IdentityDbContext : IdentityDbContext<User>
    {
        public virtual DbSet<Product> Product { get; set; }

        public virtual DbSet<ProductImage> ProductImage { get; set; }

        public virtual DbSet<ProductDetail> ProductDetail { get; set; }

        public virtual DbSet<Brand> Brand { get; set; }

        public virtual DbSet<Category> Category { get; set; }

        public virtual DbSet<Promotion> Promotion { get; set; }

        public virtual DbSet<User> User { get; set; }

        public EcommerceApp2259IdentityDbContext(DbContextOptions<EcommerceApp2259IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .Property(p => p.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Entity<Product>()
                .Property(p => p.ProductId)
                .HasDefaultValueSql("NEWID()");

            builder.Entity<Promotion>()
                .Property(p => p.PromotionId)
                .HasDefaultValueSql("NEWID()");
        }
    }
}
