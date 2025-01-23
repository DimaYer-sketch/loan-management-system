using System.ComponentModel.DataAnnotations;

namespace PayoneerServer.Models
{
    public class LoanRequest
    {
        [Required(ErrorMessage = "ClientId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "ClientId must be greater than 0.")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(1, 1000000, ErrorMessage = "Amount must be between 1 and 1,000,000.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Months is required.")]
        [Range(12, 360, ErrorMessage = "Months must be at least 12.")]
        public int Months { get; set; }
    }
}
