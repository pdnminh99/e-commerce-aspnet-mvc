using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceApp2259.Models;

namespace EcommerceApp2259.Contexts
{
    public class CategoryContext : IGenericContext<Category, int>
    {
        private readonly ApplicationContext _ctx;

        public CategoryContext(ApplicationContext ctx)
        {
            _ctx = ctx;
            // var categories =  _ctx.Category.ToList();
        }

        public Category Add(Category item)
        {
            throw new NotImplementedException();
        }

        public Category Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Category Edit(Category newCopy, bool autoInsertIfNotExist = false)
        {
            throw new NotImplementedException();
        }

        public Category Get(int categoryId)
        {
            return _ctx.Category.Find(categoryId);
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