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

        [Display(Name = "Product name")]
        public string Title { get; set; }

        [NotMapped]
        public string Image { get; set; }

        public List<ProductDetail> Details { get; set; }

        public Guid? Owner { get; set; }

        [Column("Price"), Display(Name = "Price")]
        public int OriginalPrice { get; set; }

        [DataType(DataType.DateTime), Display(Name = "Created datetime")]
        public DateTime CreatedDate { get; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Brand")]
        public string Brand { get; set; }

        public int CompareTo(Product other) => OriginalPrice.CompareTo(other.OriginalPrice);
    }

}