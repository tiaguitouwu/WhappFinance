using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhappFinance.Models
{
    public class ClientData
    {
        [Key]
        public int Id { get; set; }
        public string? Id_WA { get; set; }
        public string? Message { get; set; }
        public int IdPhoneNumber { get; set; }

        [ForeignKey("IdCategoria")]
        public PhoneNumber? PhoneNumber { get; set; }
    }
}
