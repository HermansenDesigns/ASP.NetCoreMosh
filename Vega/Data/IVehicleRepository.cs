using System.Threading.Tasks;
using Vega.Models;

namespace Vega.Data
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle (long id);
        
    }
}