using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EcommerceApp2259.Models
{
    public class Category
    {
        [Key]
        [Column("CategoryId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual List<Product> Products { get; set; }
    }
}