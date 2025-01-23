namespace PayoneerServer.Models
{
    public class CalculationDetail
    {
        public required string Calculation { get; set; } // Description of the calculation step
        public decimal Amount { get; set; } // Amount calculated for this step
    }
}
