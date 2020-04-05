
namespace EcommerceApp2259.Models
{
    public class SaleProgram
    {
        public int PercentageOff { get; set; }

#nullable enable
        public string? ProgramTitle { get; set; }

        public string Description { get; set; }

        public SaleProgram(int percentage, string title, string description)
        {
            PercentageOff = percentage;
            ProgramTitle = title;
            Description = description;
        }
    }
}