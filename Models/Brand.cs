using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EcommerceApp2259.Models
{
    [Table("Brand")]
    public class Brand
    {
        [Key, Column("BrandId")]
        public int BrandId { get; set; }
        
        public string Name { get; set; }
        
        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}