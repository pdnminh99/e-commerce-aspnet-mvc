using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceApp2259.Models;

namespace EcommerceApp2259.Contexts
{
    public class CategoryContext : IGenericContext<Category>
    {
        private readonly ApplicationContext _ctx;

        public CategoryContext(ApplicationContext ctx)
        {
            _ctx = ctx;
            var categories =  _ctx.Category.ToList();
            // Console.WriteLine($"Found {categories.Count} categories.");
        }
        
        public Category Add(Category item)
        {
            throw new NotImplementedException();
        }

        public Category Delete(Guid itemId)
        {
            throw new NotImplementedException();
        }

        public Category Edit(Category replicant, bool autoInsertIfNotExist = false)
        {
            throw new NotImplementedException();
        }

        public Category Get(Guid uuid)
        {
            throw new NotImplementedException();
        }

        public List<Category> Get()
        {
            return _ctx.Category.ToList();
        }

        public List<Category> Get(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}