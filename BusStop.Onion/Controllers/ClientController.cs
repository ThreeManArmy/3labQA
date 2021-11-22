using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusStop.Core.Client;
using BusStop.Orchestrators.BusStop;
using Microsoft.AspNetCore.Mvc;

namespace BusStop.Onion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        public ClientController(IMapper mapper, IClientService clientService)
        {
            _mapper = mapper;
            _clientService = clientService;
        }
        [HttpPost("{id")]
        public async Task<IActionResult> PostAsync(Orchestrators.Client.Client client)
        {
            var clientModel = _mapper.Map<Core.Client.Client>(client);
            var createdModel = await _clientService.AddAsync(clientModel);
            return Ok(_mapper.Map<Orchestrators.Client.Client>(createdModel));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            return Ok(_mapper.Map<Orchestrators.Client.Client>(client));
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCount count )
        {
            await _clientService.UpdateAsync(id, id);
            return Ok(_mapper.Map<Orchestrators.Client.Client>(id));
        }
        [HttpDelete("{id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _clientService.Remove(id);
            return Ok();
        }
    }
}