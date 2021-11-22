using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusStop.Core.Client;
using BusStop.Data.BusStop;
using Microsoft.EntityFrameworkCore;

namespace BusStop.Data.Client
{
    public class ClientRepository : IClientRepository

    {
        private readonly IMapper _mapper;
        private readonly BusStopContext _context;

        public ClientRepository(IMapper mapper, BusStopContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<Core.Client.Client>> GetAsync()
        {
            var entities = await _context.Clients.ToListAsync();
            return _mapper.Map<List<Core.Client.Client>>(entities);
        }

        public async Task<Core.Client.Client> GetByIdAsync(int id)
        {
            var entitie = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map <Core.Client.Client> (entitie);
        }

        public async Task<Core.Client.Client> UpdateAsync(int id, int count)
        {
            var busEntetie = _mapper.Map<BusDto>(count);

            var result =  _context.Update(busEntetie);

            return _mapper.Map<Core.Client.Client>(result.Entity);
        }

        public async Task Remove(int id)
        {
            var entetie = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
            _context.Clients.Remove(entetie);
        }

        public async Task<Core.Client.Client> AddAsync(Core.Client.Client client)
        {
            var entity = _mapper.Map<BusDto>(client);
            var result = await _context.AddAsync(entity);
            return _mapper.Map<Core.Client.Client>(result.Entity);
        }

    }

    
}