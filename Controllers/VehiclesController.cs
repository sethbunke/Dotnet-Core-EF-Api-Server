using System;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            if (vehicle == null) 
            {
                return NotFound(id);
            }

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);

        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource) 
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            System.Console.Out.WriteLine(vehicleResource);
            var vehicle = Mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var result = Mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdteVehicle(int id, [FromBody] VehicleResource vehicleResource) 
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            System.Console.Out.WriteLine(vehicleResource);

            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);
            
            if (vehicle == null) 
            {
                return NotFound(id);
            }
            
            Mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await context.SaveChangesAsync();

            var result = Mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicle(int id) 
        {
            var vehicle = await context.Vehicles.FindAsync(id);

            if (vehicle == null) 
            {
                return NotFound(id);
            }

            context.Remove(vehicle);
            await context.SaveChangesAsync();

            return Ok(id);
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