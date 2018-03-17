using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Vega.Models;

namespace Vega.Controllers.Resources
{
    public class MakeResource
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<ModelResource> Models { get; set; } = new Collection<ModelResource>();
    }
}