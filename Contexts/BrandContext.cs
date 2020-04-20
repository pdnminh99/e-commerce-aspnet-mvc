using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceApp2259.Models;

namespace EcommerceApp2259.Contexts
{
    public class BrandContext : IGenericContext<Brand, int>
    {
        private readonly ApplicationContext _ctx;

        public BrandContext(ApplicationContext ctx)
        {
            _ctx = ctx;
            // var brands = _ctx.Brand.ToList();
            // Console.WriteLine($"Found {brands.Count} brands.");
        }

        public Brand Add(Brand item)
        {
            throw new NotImplementedException();
        }

        public Brand Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public Brand Edit(Brand newCopy, bool autoInsertIfNotExist = false)
        {
            throw new NotImplementedException();
        }

        public Brand Get(int uuid)
        {
            return _ctx.Brand.Find(uuid);
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