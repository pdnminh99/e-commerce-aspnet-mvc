using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EcommerceApp2259.Models
{
    [Table("ProductDetail")]
    public class ProductDetail
    {
        public int ProductDetailId { get; set; }

        public string Keyword { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}