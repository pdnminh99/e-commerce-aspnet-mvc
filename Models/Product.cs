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

        [Display(Name = "Tên sản phẩm")]
        public string Title { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        public List<ProductDetail> Details { get; set; }

        public Guid? Owner { get; set; }

        [Column("Price"), Display(Name = "Giá")]
        public int OriginalPrice { get; set; }

        [DataType(DataType.DateTime), Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; }

        [Display(Name = "Mục sản phẩm")]
        public string Category { get; set; }

        [Display(Name = "Thương hiệu")]
        public string Brand { get; set; }

        public int CompareTo(Product other) => OriginalPrice.CompareTo(other.OriginalPrice);
    }

}