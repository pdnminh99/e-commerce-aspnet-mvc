using System;

namespace EcommerceApp2259.Models
{

    public class Product
    {
        public Guid? ProductId { get; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public Product(Guid? productId, string name, int price, DateTime createdDate, string category, string brand)
        {
            productId ??= Guid.NewGuid();
            ProductId = productId;
            Name = name;
            Price = price;
            CreatedDate = createdDate;
            Category = category;
            Brand = brand;
        }

        public Product(string name, int price, DateTime createdDate, string category, string brand)
        {
            ProductId = Guid.NewGuid();
            Name = name;
            Price = price;
            CreatedDate = createdDate;
            Category = category;
            Brand = brand;
        }
    }

}