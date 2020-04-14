

using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApp2259.Models
{
    [Table("ProductDetail")]
    public class ProductDetail
    {
        public int ProductDetailId { get; set; }
        
        public string Keyword { get; set; }
        
        public string Description { get; set; }
    }
}