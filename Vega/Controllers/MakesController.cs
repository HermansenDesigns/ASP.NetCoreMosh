using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Data;
using Vega.Models;
using Vega.Controllers.Resources;

namespace Vega.Controllers {
    [Route ("api/[controller]")]
    public class MakesController : Controller {
        private readonly VegaDbContext _context;
        private readonly IMapper mapper;

        public MakesController (VegaDbContext context, IMapper mapper) {
            this.mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<MakeResource>> GetMakes () {
            var makes =  await _context.Makes.Include (m => m.Models).ToListAsync ();

            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}