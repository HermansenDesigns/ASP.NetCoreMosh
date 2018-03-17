using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.Models
{
    public class Model
    {
        public long Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Make Make { get; set; }
        public long MakeId { get; set; }
    }
}