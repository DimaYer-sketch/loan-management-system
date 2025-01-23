using PayoneerServer.Interfaces;

namespace PayoneerServer.Models
{
    public class MidAgeClientStrategy : ILoanCalculationStrategy
    {
        public decimal CalculateBaseInterest(decimal amount)
        {
            if (amount <= 5000) return amount * 2 / 100;
            if (amount <= 30000) return amount * (1.5m + 1.5m) / 100;
            return amount * (1m + 1.5m) / 100;
        }
    }

}
