using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curiosity.Models
{
    public class Member
    {
        public int Id {get; set;}
        public string Name { get;set;}
        public string Color {get;set;}
        public ICollection<Event> Events {get;set;}
        public string UserId {get;set;}
        public ApplicationUser User {get;set;}
    }
}