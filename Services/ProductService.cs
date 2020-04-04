using EcommerceApp2259.Context;
using EcommerceApp2259.Models;
using System;
using System.Collections.Generic;

namespace EcommerceApp2259.Services
{
    public class ProductService : IProductServiceOperations
    {
        private readonly IProductContext _productCtx;

        public ProductService(IProductContext productCtx)
        {
            _productCtx = productCtx;
        }

#nullable enable
        public Product? Add(Product productToAdd)
        {
            return _productCtx.Add(productToAdd);
        }


#nullable enable
        public Product? Delete(Guid itemId)
        {
            return _productCtx.Delete(itemId);
        }

        public Product? Edit(Product replicant, bool autoInsertIfNotExist = false)
        {
            return _productCtx.Edit(replicant, autoInsertIfNotExist);
        }

#nullable enable
        public Product? Get(Guid productId)
        {
            return _productCtx.Get(productId);
        }

        public IEnumerable<Product> Get() => _productCtx.Get();

        public IEnumerable<Product> Get(String keyword)
        {
            return _productCtx.Get(keyword);
        }
    }
}