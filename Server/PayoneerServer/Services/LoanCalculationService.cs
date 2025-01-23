using PayoneerServer.Interfaces;
using PayoneerServer.Models;

namespace PayoneerServer.Services
{
    public class LoanCalculationService : ILoanCalculationService
    {
        private readonly LoanCalculationFactory _loanCalculationFactory;

        public LoanCalculationService(LoanCalculationFactory loanCalculationFactory)
        {
            _loanCalculationFactory = loanCalculationFactory;
        }

        public LoanResponse CalculateLoan(Client client, LoanRequest request)
        {
            var response = new LoanResponse();
            var details = new List<CalculationDetail>();

            // Get the appropriate strategy
            var strategy = _loanCalculationFactory.GetStrategy(client.Age);

            // Base interest calculation
            var baseInterest = strategy.CalculateBaseInterest(request.Amount);
            details.Add(new CalculationDetail
            {
                Calculation = $"Base Interest ({client.Age}-age category)",
                Amount = baseInterest
            });

            // Additional interest for months above 12
            var additionalMonths = request.Months - 12;
            var additionalInterest = additionalMonths > 0 ? request.Amount * additionalMonths * 0.0015m : 0;
            if (additionalMonths > 0)
            {
                details.Add(new CalculationDetail
                {
                    Calculation = $"Additional Interest for {additionalMonths} extra months",
                    Amount = additionalInterest
                });
            }

            // Total amount
            response.TotalAmount = request.Amount + baseInterest + additionalInterest;
            response.BaseInterest = baseInterest;
            response.AdditionalInterest = additionalInterest;
            response.Details = details;

            return response;
        }
    }
}
