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

        public virtual List<ProductImage> ProductImage { get; set; }

        [JsonIgnore]
        public virtual List<ProductDetail> ProductDetail { get; set; }

        public string Overview { get; set; }

        [JsonIgnore]
        public Guid? UserId { get; set; }

        [Column("Price"), Display(Name = "Price")]
        public int OriginalPrice { get; set; }

        [DataType(DataType.DateTime), Display(Name = "Created datetime"), JsonIgnore]
        public DateTime CreatedDate { get; set; }

        [Column("Category"), Display(Name = "Category")]
        public virtual Category Category { get; set; }

        [Column("Brand"), Display(Name = "Brand")]
        public virtual Brand Brand { get; set; }

        [Display(Name = "Stock status"), JsonIgnore]
        public int Stock { get; set; }

        [JsonIgnore]
        public int ViewsCount { get; set; }
    }
}