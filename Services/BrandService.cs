using System.Collections.Generic;
using EcommerceApp2259.Contexts;
using EcommerceApp2259.Models;

namespace EcommerceApp2259.Services
{
    public class BrandService : IBrandServiceOperations
    {
        private readonly IGenericContext<Brand> _context;

        public BrandService(IGenericContext<Brand> ctx)
        {
            _context = ctx;
        }

        public List<Brand> Get()
        {
            return _context.Get();
        }
    }
}