using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusStop.Core.BusStop;
using BusStop.Onion.BusContract;
using Microsoft.AspNetCore.Mvc;

namespace BusStop.Onion.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;
        private readonly Mapper _mapper;
        public BusController(IMapper mapper, IBusService busService)
        {
            _busService = busService;
        }
       

        [HttpGet]
        public async Task<IActionResult> GetAasync()
        {
            var buses = await _busService.GetAsync();
            return Ok(_mapper.Map<List<Onion.BusContract.Bus>>(buses));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Onion.BusContract.Bus bus)
        {
            var busModel = _mapper.Map<Core.BusStop.BusStop>(bus);
            var createdModel = await _busService.AddAsync(busModel);
            return Ok(_mapper.Map<Onion.BusContract.Bus>(createdModel));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var buses = await _busService.GetByIdAsync(Id);
            return Ok(_mapper.Map<List<Onion.BusContract.Bus>>(buses));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int Id, UpdateCount count )
        {
            await _busService.UpdateAsync(Id, Id);
            return Ok(_mapper.Map<Onion.BusContract.Bus>(Id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            await _busService.Remove(Id);
            return Ok();
        }
        
        
    }
}