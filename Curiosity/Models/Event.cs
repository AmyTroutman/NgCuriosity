using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Curiosity.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool AllDay {get;set;}
        public DateTime StartTime {get;set;}
        public DateTime EndTime { get;set;}
        public DateTime Start {get;set;}
        public DateTime End {get;set;}
        public int MemberId {get;set;}
        [JsonIgnore]
        public Member Member {get;set;}
    }
}