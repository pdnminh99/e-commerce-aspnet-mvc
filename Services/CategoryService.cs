using System.Collections.Generic;
using EcommerceApp2259.Contexts;
using EcommerceApp2259.Models;

namespace EcommerceApp2259.Services
{
    public class CategoryService : ICategoryServiceOperations
    {
        private readonly IGenericContext<Category> _context;

        public CategoryService(IGenericContext<Category> ctx)
        {
            _context = ctx;
        }
        
        public List<Category> Get()
        {
            return _context.Get();
        }
    }
}