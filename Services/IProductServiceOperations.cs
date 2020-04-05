using EcommerceApp2259.Models;
using System;
using System.Collections.Generic;

namespace EcommerceApp2259.Services
{
    public interface IProductServiceOperations
    {
#nullable enable
        public Product? Add(Product productToAdd);

#nullable enable
        public Product? Delete(Guid itemId);

        public Product? Edit(Product replicant, bool autoInsertIfNotExist = false);

#nullable enable
        public Product? Get(Guid productId);

        public List<Product> Get();

        public List<Product> Get(string keyword);
    }
}