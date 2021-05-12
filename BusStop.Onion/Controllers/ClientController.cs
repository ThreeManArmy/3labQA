using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusStop.Core.Client;
using BusStop.Onion.BusContract;
using Microsoft.AspNetCore.Mvc;

namespace BusStop.Onion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly Mapper _mapper;
        public ClientController(IMapper mapper, IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAasync()
        {
            var clients = await _clientService.GetAsync();
            return Ok(_mapper.Map<List<Onion.ClientContract.Client>>(clients));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Onion.ClientContract.Client client)
        {
            var clientModel = _mapper.Map<Core.Client.Client>(client);
            var createdModel = await _clientService.AddAsync(clientModel);
            return Ok(_mapper.Map<Onion.ClientContract.Client>(createdModel));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var Buses = await _clientService.GetByIdAsync(Id);
            return Ok(_mapper.Map<List<Onion.ClientContract.Client>>(Buses));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int Id, UpdateCount count )
        {
            await _clientService.UpdateAsync(Id, Id);
            return Ok(_mapper.Map<Onion.ClientContract.Client>(Id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            await _clientService.Remove(Id);
            return Ok();
        }
    }
}