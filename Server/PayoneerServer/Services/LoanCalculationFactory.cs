using PayoneerServer.Interfaces;
using PayoneerServer.Models;

namespace PayoneerServer.Services
{
    public class LoanCalculationFactory
    {
        public ILoanCalculationStrategy GetStrategy(int age)
        {
            return age switch
            {
                < 20 => new YoungClientStrategy(),
                <= 35 => new MidAgeClientStrategy(),
                _ => new SeniorClientStrategy()
            };
        }
    }
}
