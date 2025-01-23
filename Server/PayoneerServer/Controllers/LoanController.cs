using Microsoft.AspNetCore.Mvc;
using PayoneerServer.Interfaces;
using PayoneerServer.Models;

namespace PayoneerServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LoanController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly ILoanCalculationService _loanCalculationService;

        public LoanController(IClientRepository clientRepository, ILoanCalculationService loanCalculationService)
        {
            _clientRepository = clientRepository;
            _loanCalculationService = loanCalculationService;
        }

        /// <summary>
        /// Calculates the total loan amount, including interest.
        /// </summary>
        /// <param name="request">LoanRequest object containing client ID, loan amount, and period in months.</param>
        /// <returns>Returns the total loan amount and interest breakdown.</returns>
        /// <response code="200">Loan calculation successful.</response>
        /// <response code="400">Validation failed.</response>
        /// <response code="404">Client not found.</response>
        [HttpPost("calculate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CalculateLoan([FromBody] LoanRequest request)
        {
            var client = await _clientRepository.GetClientByIdAsync(request.ClientId);
            if (client == null)
            {
                return NotFound(new { Message = $"Client with ID {request.ClientId} not found." });
            }

            var loanResponse = _loanCalculationService.CalculateLoan(client, request);

            return Ok(loanResponse);
        }

        /// <summary>
        /// Retrieves all registered clients.
        /// </summary>
        /// <returns>Returns a list of all clients.</returns>
        /// <response code="200">Clients retrieved successfully.</response>
        [HttpGet("clients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientRepository.GetAllClientsAsync();
            return Ok(clients);
        }
    }
}
