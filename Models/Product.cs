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

        public string Title { get; set; }

        public Guid Owner { get; set; }

        public int Price { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; }

        public string Category { get; set; }

        public string Brand { get; set; }
    }

}