using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusStop.Core.Client
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAsync();
        Task<Client> GetByIdAsync(int id);
        Task<Client> UpdateAsync(int id, int count);
        Task Remove(int id);
        Task<Client> AddAsync(Client client);
    }
}