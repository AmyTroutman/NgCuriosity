using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Curiosity.Models;
using Curiosity.Data;
using System.Security.Claims;

namespace Curiosity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotBevsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public HotBevsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<HotBev> Get()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _context.HotBevs.Where(b => b.UserId == userId).ToArray();
        }

         [HttpGet("{id}")]
        public HotBev Get([FromRoute] int id)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var hotBev = _context.HotBevs.Where(b => b.UserId == userId).FirstOrDefault(b => b.Id == id);
            if(hotBev == null) return null;
            return hotBev;
        }

        [HttpPost]
        public HotBev Post([FromBody] HotBev hotBev)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            hotBev.UserId = userId;
            _context.HotBevs.Add(hotBev);
            _context.SaveChanges();
            return hotBev;
        }

        [HttpPut("{id}")]
        public HotBev Put([FromRoute] int id, [FromBody] HotBev hotBev)
        {
            // var currentHotBev = _context.HotBevs.Find(HotBev.Id);
            // I think this is the one I want:
            var currentHotBev = _context.HotBevs.Find(hotBev.Id);
            if(currentHotBev == null) return null;
           
            _context.Entry(currentHotBev).CurrentValues.SetValues(hotBev);
            _context.HotBevs.Update(currentHotBev);
            _context.SaveChanges();
            return currentHotBev;
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            var hotBev = _context.HotBevs.FirstOrDefault(b => b.Id == id);
            _context.HotBevs.Remove(hotBev);
            _context.SaveChanges();
        }
    }
}
