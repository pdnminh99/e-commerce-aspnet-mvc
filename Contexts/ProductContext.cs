using Microsoft.EntityFrameworkCore;
using EcommerceApp2259.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp2259.Context
{
    public class ProductContext : DbContext
    {
        private DbSet<Product> products { get; set; }

        private DbSet<User> users { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public Task<List<Product>> getAll() => products.ToListAsync();

        public async Task<Product> getFirst() => await products.FirstOrDefaultAsync(p => true);
    }
}