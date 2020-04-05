using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EcommerceApp2259.Models
{
    [Table("Product")]
    public class Product : IComparable<Product>
    {
        [Key]
        public Guid ProductId { get; set; }

        public string Title { get; set; }

        public string Images { get; set; }

        public Guid? Owner { get; set; }

        public int OriginalPrice { get; set; }

        public string Currency { get; set; }

        public double ActualPrice
        {
            get => _sale == null ? OriginalPrice : 1.0 * OriginalPrice * Sale.PercentageOff / 100;
        }

        public string LocaleActualPrice
        {
            get => $"{ActualPrice} ${Currency}";
        }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; }

        public string Category { get; set; }

        public string Brand { get; set; }

        public int Stock { get; set; }

        private SaleProgram _sale;

        [NotMapped]
        public SaleProgram Sale
        {
            get => _sale;
        }

        public Product(Guid productId, string title, Guid? owner, int price, DateTime createdDate, string category, string brand, int? stock, string images)
        {
            ProductId = productId;
            Title = title;
            Owner = owner;
            OriginalPrice = price;
            CreatedDate = createdDate;
            Category = category;
            Brand = brand;
            Images = images;
            Stock = stock ?? 100;
        }

        public int CompareTo(Product other) => ActualPrice.CompareTo(other.ActualPrice);
    }

}