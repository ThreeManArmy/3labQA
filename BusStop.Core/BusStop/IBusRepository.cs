using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusStop.Core.BusStop
{
    public interface IBusRepository
    {
        Task<List<BusStop>> GetAsync();
        Task<BusStop> GetByIdAsync(int id);
        Task<BusStop> UpdateAsync(int id, int count);
        Task Remove(int id);
        Task<BusStop> AddAsync(BusStop busStop);
    }
}