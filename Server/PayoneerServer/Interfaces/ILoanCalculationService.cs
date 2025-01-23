using PayoneerServer.Models;

namespace PayoneerServer.Interfaces
{
    public interface ILoanCalculationService
    {
        LoanResponse CalculateLoan(Client client, LoanRequest request); // Calculate loan details
    }
}
