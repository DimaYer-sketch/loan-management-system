namespace PayoneerServer.Interfaces
{
    public interface ILoanCalculationStrategy
    {
        decimal CalculateBaseInterest(decimal amount); // Calculate base interest
    }
}
