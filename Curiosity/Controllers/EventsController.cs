using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curiosity.Data;
using Curiosity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace capstone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {

        private ApplicationDbContext _context;
        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _context.Events.Include(b =>b.Member).Where(b => b.Member.UserId == userId).ToArray();
        }

        [HttpGet("{id}")]
        public Event Get([FromRoute] int id)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var plan = _context.Events.Include(b =>b.Member).Where(b => b.Member.UserId == userId).FirstOrDefault(b => b.Id == id);
            if(plan == null) return null;
            return plan;
        }

        [HttpPost]
        public Event Post([FromBody] Event plan)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            plan.Member.UserId = userId;
            _context.Events.Add(plan);
            _context.SaveChanges();
            return plan;
        }

        [HttpPut("{id}")]
        public Event Put([FromRoute] int id, [FromBody] Event plan)
        {
            // var currentBook = _context.Books.Find(book.Id);
            // I think this is the one I want:
            var currentPlan = _context.Events.Find(plan.Id);
            if(currentPlan == null) return null;
           
            _context.Entry(currentPlan).CurrentValues.SetValues(plan);
            _context.Events.Update(currentPlan);
            _context.SaveChanges();
            return currentPlan;
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            var plan = _context.Events.FirstOrDefault(b => b.Id == id);
            _context.Events.Remove(plan);
            _context.SaveChanges();
        }
    }
}