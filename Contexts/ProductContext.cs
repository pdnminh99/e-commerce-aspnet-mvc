using EcommerceApp2259.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace EcommerceApp2259.Context
{
    public class ProductContext : IProductContext
    {
        private readonly ApplicationContext _ctx;

        public ProductContext(ApplicationContext ctx)
        {
            _ctx = ctx;
        }
        public Product Add(Product item)
        {
            _ctx.Product.Add(item);
            return item;
        }

        public Product Delete(Guid itemId)
        {
            var productToDelete = Get(itemId);
            if (productToDelete != null) _ctx.Product.Remove(productToDelete);
            return productToDelete;
        }

        public Product Edit(Product replicant, bool autoInsertIfNotExist = false)
        {
            return replicant;
        }

        public Product Get(Guid uuid)
        {
            return _ctx.Product.First(p => p.ProductId == uuid);
        }

        public List<Product> Get()
        {
            var images = _ctx.ProductImage.ToList();
            Console.WriteLine(images.Count);
            return _ctx.Product.ToList();
        }

        public List<Product> Get(string keyword)
        {
            return _ctx.Product.Where(p => p.Brand.Contains(keyword) || p.Category.Contains(keyword) || p.Title.Contains(keyword)).ToList();
        }
    }
}