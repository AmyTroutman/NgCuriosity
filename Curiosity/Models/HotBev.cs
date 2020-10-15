using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curiosity.Models
{
    public class HotBev
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id {get;set;}
        public string Brand {get;set;}
        public string Name {get;set;}
        public string Type {get;set;}
        public string Subtype {get;set;}
        public string Review {get;set;}
        public string Mood {get;set;}
        public string UserId {get;set;}
        public ApplicationUser User {get;set;}
    }
}
