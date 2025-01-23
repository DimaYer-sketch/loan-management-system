using PayoneerServer.Interfaces;

namespace PayoneerServer.Models
{
    public class YoungClientStrategy : ILoanCalculationStrategy
    {
        public decimal CalculateBaseInterest(decimal amount) => amount * (2m + 1.5m) / 100m;
    }
}
