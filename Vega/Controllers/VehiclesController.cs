using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vega.Controllers.Resources;
using Vega.Data;
using Vega.Models;

namespace Vega.Controllers 
{
    [Route ("api/[controller]")]
    public class VehiclesController : Controller {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        public VehiclesController (VegaDbContext context, IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle ([FromBody] VehicleResource vehicleResource) 
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<VehicleResource, Vehicle> (vehicleResource);

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var result =  mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CreateVehicle ([FromRoute] long id, [FromBody] VehicleResource vehicleResource) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await context.Vehicles.FindAsync(id);

            mapper.Map<VehicleResource, Vehicle> (vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.UtcNow;

            await context.SaveChangesAsync();

            var result =  mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }



    }
}