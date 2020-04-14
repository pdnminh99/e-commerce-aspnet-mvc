

namespace EcommerceApp2259.Models
{
    public class ProductDetail
    {
        public string ProductDetailId { get; set; }
        
        public string Keyword { get; set; }
        
        public string Description { get; set; }
        
        public ProductDetail(string productDetailId, string keyword, string description)
        {
            ProductDetailId = productDetailId;
            Keyword = keyword;
            Description = description;
        }
    }
}