using AppData.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configiguration;
        public AppDbContext(IConfiguration configuration) {
            _configiguration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configiguration.GetConnectionString("DemoDb"));
        }
        public DbSet<Person> people { get; set; }
    }
}
