using System.ComponentModel.DataAnnotations;

namespace WhappFinanceApi.Models
{
    public class ClientData
    {
        [Key]
        public int Id { get; set; }
        public string? Id_WA { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Message { get; set; }
    }
}
