using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;

namespace EcommerceApp2259.Models
{
    public class Product : IComparable<Product>
    {
        public Guid ProductId { get; set; }

        public string Title { get; set; }

        [Column("ProductImage")]
        public IEnumerable<ProductImage> Images { get; set; }

        [Column("ProductDetail")]
        public List<ProductDetail> Details { get; set; }

        public Guid? Owner { get; set; }

        [Column("Price")]
        public int OriginalPrice { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; }

        public string Category { get; set; }

        public string Brand { get; set; }

        public int CompareTo(Product other) => OriginalPrice.CompareTo(other.OriginalPrice);
    }

}