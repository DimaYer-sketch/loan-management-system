using PayoneerServer.Interfaces;

namespace PayoneerServer.Models
{
    public class SeniorClientStrategy : ILoanCalculationStrategy
    {
        public decimal CalculateBaseInterest(decimal amount)
        {
            if (amount <= 15000) return amount * (1.5m + 1.5m) / 100;
            if (amount <= 30000) return amount * (3m + 1.5m) / 100;
            return amount * 1 / 100;
        }
    }
}
