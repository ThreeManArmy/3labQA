
using System.Collections.Generic;
using System.Threading.Tasks;
using BusStop.Core.Client;

namespace BusStop.Orchestrators.Client
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<List<Core.Client.Client>> GetAsync()
        {
            return await _clientRepository.GetAsync();
        }

        public async Task<Core.Client.Client> GetByIdAsync(int id)
        {
            
            return await _clientRepository.GetByIdAsync(id);
        }

        public async Task<Core.Client.Client> UpdateAsync(int id, int count)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            client.CountOfTravels = count;
            await _clientRepository.UpdateAsync(id, count);
            return client;
        }

        public async Task Remove(int id)
        {
            await _clientRepository.Remove(id);
        }

        public async Task<Core.Client.Client> AddAsync(Core.Client.Client client)
        {
            return await _clientRepository.AddAsync(client);
        }
    }
}