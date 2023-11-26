using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInitium.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AthleteContext>
    {
        public AthleteContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../PruebaInitium.API/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<AthleteContext>();
            var connectionString = configuration.GetConnectionString("AthleteDB");
            builder.UseSqlServer(connectionString);
            return new AthleteContext(builder.Options);
        }
    }
}
