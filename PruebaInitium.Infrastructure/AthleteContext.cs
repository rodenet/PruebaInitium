using Microsoft.EntityFrameworkCore;
using PruebaInitium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInitium.Infrastructure
{
    public class AthleteContext : DbContext
    { 
        public AthleteContext(DbContextOptions<AthleteContext> options)
        : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Athlete> Athletes { get; set; }

        public DbSet<Entry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var countries = new Country[]
            {
                new Country()
                {
                    Id = new Guid("91990c4e-6aea-4b16-a14d-3cb78503d146"),
                    Code = "ESP",
                },
                new Country()
                {
                    Id = new Guid("e65f0820-ad0c-43fb-aa66-77ea63e910b9"),
                    Code = "ARG",
                },
                new Country()
                {
                    Id = new Guid("ea4c9d6d-b826-40e2-bf6f-e4cd9ae227ed"),
                    Code = "COL",
                }
            };

            builder.Entity<Country>().HasData(countries); 
        }
    }
}
