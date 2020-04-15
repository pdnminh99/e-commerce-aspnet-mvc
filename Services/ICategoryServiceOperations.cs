using System.Collections.Generic;
using EcommerceApp2259.Models;

namespace EcommerceApp2259.Services
{
    public interface ICategoryServiceOperations
    {
        public List<Category> Get();
    }
}