using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EcommerceApp2259.Models;

namespace EcommerceApp2259.Areas.Identity.Data
{
    public class EcommerceApp2259IdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<Product> Product { get; set; }

        public virtual DbSet<ProductImage> ProductImage { get; set; }

        public virtual DbSet<ProductDetail> ProductDetail { get; set; }

        public virtual DbSet<Brand> Brand { get; set; }

        public virtual DbSet<Category> Category { get; set; }

        public EcommerceApp2259IdentityDbContext(DbContextOptions<EcommerceApp2259IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
