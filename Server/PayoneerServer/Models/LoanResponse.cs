namespace PayoneerServer.Models
{
    public class LoanResponse
    {
        public decimal TotalAmount { get; set; } // Total amount including interest
        public decimal BaseInterest { get; set; } // Base interest amount
        public decimal AdditionalInterest { get; set; } // Interest for extra months
        public List<CalculationDetail> Details { get; set; } = new(); // Detailed breakdown
    }
}
