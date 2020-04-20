using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EcommerceApp2259.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }

        [Display(Name = "Product name")] public string Title { get; set; }

        public List<ProductImage> ProductImage { get; set; }

        public List<ProductDetail> ProductDetail { get; set; }

        public string Overview { get; set; }

        [JsonIgnore]
        public Guid? UserId { get; set; }

        [Column("Price"), Display(Name = "Price")]
        public int OriginalPrice { get; set; }

        [DataType(DataType.DateTime), Display(Name = "Created datetime")]
        public DateTime CreatedDate { get; }

        [Column("Category"), Display(Name = "Category")]
        public Category Category { get; set; }

        [Column("Brand"), Display(Name = "Brand")]
        public Brand Brand { get; set; }
    }
}