using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace EcommerceApp2259.Models
{
    public class Promotion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PromotionId { get; set; }

        public string Description { get; set; }

#nullable enable
        public string? Title { get; set; }

        public int? SaleOffPercentages { get; set; }
#nullable disable
    }
}