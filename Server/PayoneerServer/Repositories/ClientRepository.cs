using PayoneerServer.Interfaces;
using PayoneerServer.Models;
using System.Text.Json;

namespace PayoneerServer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _filePath = "Data/clients.json";
        private readonly List<Client> _clients;

        public ClientRepository()
        {
            if (File.Exists(_filePath))
            {
                var jsonData = File.ReadAllText(_filePath);
                _clients = JsonSerializer.Deserialize<List<Client>>(jsonData) ?? new List<Client>();
            }
            else
            {
                _clients = new List<Client>();
            }
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            // Return the clients asynchronously
            return await Task.FromResult<IEnumerable<Client>>(_clients);
        }

        public async Task<Client?> GetClientByIdAsync(int id)
        {
            // Find a client by ID asynchronously
            var client = _clients.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(client);
        }
    }
}
