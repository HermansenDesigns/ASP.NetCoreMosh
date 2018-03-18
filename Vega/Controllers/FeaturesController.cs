using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Controllers.Resources;
using Vega.Data;
using Vega.Models;

namespace Vega.Controllers {

    [Route ("api/[controller]")]
    public class FeaturesController : Controller {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public FeaturesController (VegaDbContext context, IMapper mapper) {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<KeyValuePairResource>> GetFeatures () {
            var features = await context.Features.ToListAsync ();

            return mapper.Map<List<Feature>, List<KeyValuePairResource>>(features);
        }
    }
}