using System;

namespace EcommerceApp2259.Models
{

    public class Product
    {
        public string name { get; set; }
        public int price { get; set; }
        public DateTime createdDate { get; }
        public string category { get; set; }
        public string brand { get; set; }
        public Product(string name, int price, DateTime createdDate, string category, string brand)
        {
            this.name = name;
            this.price = price;
            this.createdDate = createdDate;
            this.category = category;
            this.brand = brand;
        }
    }

}