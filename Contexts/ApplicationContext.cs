// using Microsoft.EntityFrameworkCore;
// using EcommerceApp2259.Models;

// namespace EcommerceApp2259.Contexts
// {
//     public class ApplicationContext : DbContext
//     {
//         public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
//         {
//         }

//         public virtual DbSet<Product> Product { get; set; }

//         public virtual DbSet<ProductImage> ProductImage { get; set; }

//         public virtual DbSet<ProductDetail> ProductDetail { get; set; }

//         public virtual DbSet<Brand> Brand { get; set; }

//         public virtual DbSet<Category> Category { get; set; }

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//         }
//     }
// }