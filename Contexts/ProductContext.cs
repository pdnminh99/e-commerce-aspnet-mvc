using EcommerceApp2259.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceApp2259.Contexts
{
    public class ProductContext : IGenericContext<Product, Guid>
    {
        private readonly ApplicationContext _ctx;

        public ProductContext(ApplicationContext ctx)
        {
            _ctx = ctx;
            _ctx.ProductImage.ToList();
            _ctx.ProductDetail.ToList();
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

        public Product Edit(Product newCopy, bool autoInsertIfNotExist = false)
        {
            return newCopy;
        }

        public Product Get(Guid uuid)
        {
            return _ctx.Product.First(p => p.ProductId == uuid);
        }

        public List<Product> Get()
        {
            return _ctx.Product.ToList();
        }

        public List<Product> Get(string keyword)
        {
            return _ctx.Product.Where(p =>
                p.Brand.Name.Contains(keyword) || p.Category.Name.Contains(keyword) || p.Title.Contains(keyword)).ToList();
        }
    }
}