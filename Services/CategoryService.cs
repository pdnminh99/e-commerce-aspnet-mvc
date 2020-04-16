using System;
using System.Collections.Generic;
using EcommerceApp2259.Contexts;
using EcommerceApp2259.Models;

namespace EcommerceApp2259.Services
{
    public class CategoryService : ICategoryServiceOperations
    {
        private readonly IGenericContext<Category, int> _context;

        public CategoryService(IGenericContext<Category, int> ctx)
        {
            _context = ctx;
        }
        
        public List<Category> Get()
        {
            return _context.Get();
        }

        public Category Get(int categoryId)
        {
            return _context.Get(categoryId);
        }
    }
}