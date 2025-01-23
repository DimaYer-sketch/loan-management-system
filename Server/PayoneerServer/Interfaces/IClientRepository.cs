using PayoneerServer.Models;
using System.Threading.Tasks;

namespace PayoneerServer.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllClientsAsync(); // Retrieve all clients asynchronously
        Task<Client?> GetClientByIdAsync(int id);       // Retrieve a single client by ID asynchronously
    }
}
