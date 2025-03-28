using System.ComponentModel.DataAnnotations;

namespace WhappFinance.Models
{
    public class PhoneNumber
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Number { get; set; }
        public string? ContactName { get; set; }
    }
}
