using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet_Core_EF_Api_Server.Controllers.Resources;
using Dotnet_Core_EF_Api_Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Core_EF_Api_Server.Controllers
{
    public class MakesController : Controller
    {
        private readonly Dotnet_Core_EF_Api_Server.Persistence.VegaDbContext context;
        private readonly IMapper mapper;

        public MakesController(Dotnet_Core_EF_Api_Server.Persistence.VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var results = await context.Makes.Include(m => m.Models).ToListAsync().ConfigureAwait(false);
            var mappedResults = Mapper.Map<List<Make>, List<MakeResource>>(results);
            return mappedResults;
        }
    }
}