using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnet_Core_EF_Api_Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Core_EF_Api_Server.Controllers
{
    public class MakesController : Controller
    {
        private readonly VegaDbContext context;

        public MakesController(VegaDbContext context)
        {
            this.context = context;

        }
        
        [HttpGet("/api/makes")]
        public async Task<IEnumerable<Make>> GetMakes()
        {
            var results = await context.Makes.Include(m => m.Models).ToListAsync().ConfigureAwait(false);
            return results;
        }
    }
}