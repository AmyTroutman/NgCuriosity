using AutoMapper.Configuration;
using Curiosity.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curiosity.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public IConfiguration Configuration { get; }
        public DbSet<Event> Events {get;set;}
        public DbSet<Member> Members {get;set;}
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public ApplicationDbContext() : base(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite("Data Source=app.db").Options,null)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Member>().HasData(
                new Member { Id = 1, Name = "Amy", Color = "#0cf5bf", UserId = null }
            );

            builder.Entity<Event>().HasData(
                new Event { Id = 1, Title = "Tutor Caudle", AllDay = false, StartTime = new DateTime(14-45-00), EndTime = new DateTime(15-45-00), Start = new DateTime(2020-10-13), End = new DateTime(2020-10-13), MemberId = 1}
            );
        }
    }
}
