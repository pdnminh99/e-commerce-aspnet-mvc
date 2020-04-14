using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace EcommerceApp2259.Models
{
    [Table("ProductImage")]
    public class ProductImage
    {
        [Key] public int ImageId { get; set; }

        [Column("URI")] public String URI { get; set; }
    }
}