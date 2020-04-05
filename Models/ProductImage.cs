using System.ComponentModel.DataAnnotations;

namespace EcommerceApp2259.Models
{
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }
        public string URI { get; set; }
    }
}