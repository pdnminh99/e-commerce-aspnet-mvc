using System.Collections.Generic;
using EcommerceApp2259.Contexts;
using EcommerceApp2259.Models;

namespace EcommerceApp2259.Services
{
    public class BrandService : IBrandServiceOperations
    {
        private readonly IGenericContext<Brand, int> _context;

        public BrandService(IGenericContext<Brand, int> ctx)
        {
            _context = ctx;
        }

        public List<Brand> Get()
        {
            return _context.Get();
        }
        
        public Brand Get(int brandId)
        {
            return _context.Get(brandId);
        }
    }
}