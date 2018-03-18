using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Controllers.Resources;
using Vega.Data;
using Vega.Models;

namespace Vega.Controllers 
{
    [Route ("api/[controller]")]
    public class VehiclesController : Controller 
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        private readonly IVehicleRepository repository;
        public VehiclesController (VegaDbContext context, IVehicleRepository repository, IMapper mapper) 
        {
            this.repository = repository;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle ([FromBody] SaveVehicleResource vehicleResource) 
        {

            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle> (vehicleResource);

            context.Vehicles.Add (vehicle);
            await context.SaveChangesAsync ();

            vehicle = await repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource> (vehicle);

            return Ok (result);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateVehicle ([FromRoute] long id, [FromBody] SaveVehicleResource vehicleResource) 
        {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound ();

            mapper.Map<SaveVehicleResource, Vehicle> (vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.UtcNow;

            await context.SaveChangesAsync ();

            var result = mapper.Map<Vehicle, VehicleResource> (vehicle);

            return Ok (result);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteVehicle ([FromRoute] long id) 
        {
            var vehicle = await context.Vehicles.FindAsync (id);

            if (vehicle == null)
                return NotFound ();

            context.Remove (vehicle);
            await context.SaveChangesAsync ();
            return Ok (id);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetVehicle ([FromRoute] long id) 
        {
            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound ();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource> (vehicle);

            return Ok (vehicleResource);
        }
    }
}