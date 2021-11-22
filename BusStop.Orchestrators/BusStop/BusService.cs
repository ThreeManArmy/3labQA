using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusStop.Core.BusStop;

namespace BusStop.Orchestrators.BusStop
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;
        public BusService(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }
        public async Task<List<Core.BusStop.BusStop>> GetAsync()
        {
            return await _busRepository.GetAsync();
        }
        public async Task<Core.BusStop.BusStop> GetByIdAsync(int id)
        {
            return await _busRepository.GetByIdAsync(id);
        }
        public async Task<Core.BusStop.BusStop> UpdateAsync(int id, int count)
        {
            var busStop = await _busRepository.GetByIdAsync(id);
            busStop.CountOfBuses = count;
            await _busRepository.UpdateAsync(id, count);
            return busStop;
        }
        public async Task Remove(int id)
        {
            await _busRepository.Remove(id);
        }
        public async Task<Core.BusStop.BusStop> AddAsync(Core.BusStop.BusStop busStop)
        {
            return await _busRepository.AddAsync(busStop);
        }
    }
}