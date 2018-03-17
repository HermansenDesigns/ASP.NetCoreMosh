using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.Models
{
    [Table("VehicleFeatures")]
    public class VehicleFeature
    {
        public long VehicleId { get; set; }
        public long FeatureId { get; set; }

        public Vehicle Vehicle { get; set; }
        public Feature Feature { get; set; }
    }
}