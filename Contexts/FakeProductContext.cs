
using EcommerceApp2259.Models;
using System.Collections.Generic;
using System;

namespace EcommerceApp2259.Context
{
    public class FakeProductContext : IProductContext
    {
        private List<Product> products = new List<Product>();

#nullable enable
        public Product? Add(Product productToAdd)
        {
            foreach (var product in products)
            {
                if (product.ProductId.Equals(productToAdd.ProductId))
                {
                    return null;
                }
            }
            products.Add(productToAdd);
            return productToAdd;
        }

#nullable enable
        public Product? Delete(Guid itemId)
        {
            if (itemId == null)
            {
                return null;
            }
            Product? productToDelete = null;
            foreach (var product in products)
            {
                if (product.ProductId.Equals(itemId))
                {
                    products.Remove(product);
                    return product;
                }
            }
            return productToDelete;
        }

        public Product? Edit(Product replicant, bool autoInsertIfNotExist = false)
        {
            for (int index = 0; index < products.Count; index++)
            {
                if (products[index].ProductId.Equals(replicant.ProductId))
                {
                    products[index] = replicant;
                    return replicant;
                }
            }
            if (autoInsertIfNotExist)
            {
                products.Add(replicant);
                return replicant;
            }
            return null;
        }

#nullable enable
        public Product? Get(Guid productId)
        {
            foreach (var product in products)
            {
                if (product.ProductId.Equals(productId))
                {
                    return product;
                }
            }
            return null;
        }

        public IEnumerable<Product> Get() => products;

        public IEnumerable<Product> Get(String keyword)
        {
            var results = new List<Product>();
            foreach (var product in products)
            {
                if (product.Title.Contains(keyword) || product.Brand.Contains(keyword) || product.Category.Contains(keyword))
                {
                    results.Add(product);
                }
            }
            return products;
        }
    }
}