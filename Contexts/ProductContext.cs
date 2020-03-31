// using Microsoft.EntityFrameworkCore;
// using EcommerceApp2259.Models;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace EcommerceApp2259.Context
// {
//     public class ProductContext : DbContext
//     {
//         DbSet<Product> products;

//         public ProductContext(DbContextOptions<ProductContext> options)
//             : base(options)
//         {
//         }

//         public async Task<List<Product>> getAll() {
//             return await products.ToListAsync();
//         }

//         public async Task<Product> getFirst() {
//             return await products.FirstOrDefaultAsync(p => true);
//         }
//     }
// }