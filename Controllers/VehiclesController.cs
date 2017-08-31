using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet_Core_EF_Api_Server.Controllers.Resources;
using Dotnet_Core_EF_Api_Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Core_EF_Api_Server.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly Dotnet_Core_EF_Api_Server.Persistence.VegaDbContext context;
        private readonly IMapper mapper;

        public VehiclesController(Dotnet_Core_EF_Api_Server.Persistence.VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource) 
        {
            System.Console.Out.WriteLine(vehicleResource);
            var vehicle = Mapper.Map<VehicleResource, Vehicle>(vehicleResource);

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var updatedVehicleResource = Mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(updatedVehicleResource);
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