using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet_Core_EF_Api_Server.Controllers.Resources;
using Dotnet_Core_EF_Api_Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Core_EF_Api_Server.Controllers
{
    public class VehicleController : Controller
    {
        private readonly Dotnet_Core_EF_Api_Server.Persistence.VegaDbContext context;
        private readonly IMapper mapper;

        public VehicleController(Dotnet_Core_EF_Api_Server.Persistence.VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        // [HttpGet("/api/features")]
        // public async Task<IEnumerable<FeatureResource>> GetFeatures()
        // {
        //     var results = await context.Features.ToListAsync().ConfigureAwait(false);
        //     var mappedResults = Mapper.Map<List<Feature>, List<FeatureResource>>(results);
        //     return mappedResults;
        // }
    }
}