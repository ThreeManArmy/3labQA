using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusStop.Core.Client
{
    public interface IClientService
    {
        Task<List<Client>> GetAsync();
        Task<Client> GetByIdAsync(int Id);
        Task<Client> UpdateAsync(int Id, int count);
        Task Remove(int Id);
        Task<Client> AddAsync(Client client);
    }
}