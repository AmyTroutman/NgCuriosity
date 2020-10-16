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
    public class MembersController : ControllerBase
    {

        private ApplicationDbContext _context;
        public MembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Member> Get()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _context.Members.Include(b =>b.Events).Where(b => b.UserId == userId).ToArray();
        }

        [HttpGet("{id}")]
        public Member Get([FromRoute] int id)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var member = _context.Members.Include(b =>b.Events).Where(b => b.UserId == userId).FirstOrDefault(b => b.Id == id);
            if(member == null) return null;
            return member;
        }

        [HttpPost]
        public Member Post([FromBody] Member member)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            member.UserId = userId;
            _context.Members.Add(member);
            _context.SaveChanges();
            return member;
        }

        [HttpPut("{id}")]
        public Member Put([FromRoute] int id, [FromBody] Member member)
        {
            // var currentBook = _context.Books.Find(book.Id);
            // I think this is the one I want:
            var currentmember = _context.Members.Find(member.Id);
            if(currentmember == null) return null;
           
            _context.Entry(currentmember).CurrentValues.SetValues(member);
            _context.Members.Update(currentmember);
            _context.SaveChanges();
            return currentmember;
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            var member = _context.Members.FirstOrDefault(b => b.Id == id);
            _context.Members.Remove(member);
            _context.SaveChanges();
        }
    }
}