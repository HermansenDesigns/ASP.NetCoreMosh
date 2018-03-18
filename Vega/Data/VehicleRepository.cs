using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Models;

namespace Vega.Data
{

    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext context;
        public VehicleRepository (VegaDbContext context) 
        {
            this.context = context;
        }

        public async Task<Vehicle> GetVehicle (long id) 
        {
            return await context.Vehicles
                .Include (v => v.Features)
                    .ThenInclude (vf => vf.Feature)
                .Include (v => v.Model)
                    .ThenInclude (m => m.Make)
                .SingleOrDefaultAsync (v => v.Id == id);
        }
    }
}