using System;

namespace EcommerceApp2259.Models
{

    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public Product(string name, int price, DateTime createdDate, string category, string brand)
        {
            Name = name;
            Price = price;
            CreatedDate = createdDate;
            Category = category;
            Brand = brand;
        }
    }

}