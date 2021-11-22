using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusStop.Core.BusStop;
using BusStop.Orchestrators.BusStop;
using Microsoft.AspNetCore.Mvc;

namespace BusStop.Onion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;
        private readonly IMapper _mapper;
        public BusController(IMapper mapper, IBusService busService)
        {
            _mapper = mapper;
            _busService = busService;
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> PostAsync(BusStop.Orchestrators.BusStop.Bus bus)
        {
            var busModel = _mapper.Map<Core.BusStop.BusStop>(bus);
            var createdModel = await _busService.AddAsync(busModel);
            return Ok(_mapper.Map<BusStop.Orchestrators.BusStop.Bus>(createdModel));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var buses = await _busService.GetByIdAsync(id);
            return Ok(_mapper.Map<BusStop.Orchestrators.BusStop.Bus>(buses));
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCount count )
        {
            await _busService.UpdateAsync(id, count.Count);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _busService.Remove(id);
            return Ok();
        }
    }
}