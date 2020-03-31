using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp2259.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("Owner")]
        public Guid OwnerId { get; set; }

        [Column("Price")]
        public int Price { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; }

        [Column("Category")]
        public int Category { get; set; }

        [Column("Brand")]
        public int Brand { get; set; }
    }

}