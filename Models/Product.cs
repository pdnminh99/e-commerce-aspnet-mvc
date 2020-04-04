using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp2259.Models
{
    [Table("Product")]
    public class Product : IComparable<Product>
    {
        [Key]
        public Guid ProductId { get; set; }

        public string Title { get; set; }

        public Guid? Owner { get; set; }

        public int Price { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; }

        public string Category { get; set; }

        public string Brand { get; set; }

        public Product(Guid productId, string title, Guid? owner, int price, DateTime createdDate, string category, string brand)
        {
            ProductId = productId;
            Title = title;
            Owner = owner;
            price = Price;
            CreatedDate = createdDate;
            Category = category;
            Brand = brand;
        }

        public int CompareTo(Product other)
        {
            return 1;
        }
    }

}