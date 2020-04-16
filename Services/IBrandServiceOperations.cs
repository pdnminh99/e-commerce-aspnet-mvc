using System.Collections.Generic;
using EcommerceApp2259.Models;

namespace EcommerceApp2259.Services
{
    public interface IBrandServiceOperations
    {
        public List<Brand> Get();

        public Brand Get(int brandId);
    }
}