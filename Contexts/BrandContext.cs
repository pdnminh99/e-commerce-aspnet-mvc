using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceApp2259.Models;

namespace EcommerceApp2259.Contexts
{
    public class BrandContext : IGenericContext<Brand>
    {
        private readonly ApplicationContext _ctx;

        public BrandContext(ApplicationContext ctx)
        {
            _ctx = ctx;
            var brands = _ctx.Brand.ToList();
            // Console.WriteLine($"Found {brands.Count} brands.");
        }
        
        public Brand Add(Brand item)
        {
            throw new NotImplementedException();
        }

        public Brand Delete(Guid itemId)
        {
            throw new NotImplementedException();
        }

        public Brand Edit(Brand replicant, bool autoInsertIfNotExist = false)
        {
            throw new NotImplementedException();
        }

        public Brand Get(Guid uuid)
        {
            throw new NotImplementedException();
        }

        public List<Brand> Get()
        {
            return _ctx.Brand.ToList();
        }

        public List<Brand> Get(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}