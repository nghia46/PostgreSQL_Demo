using AppData.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AppData
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("StudentDb"));
        }
//Table
        public required DbSet<Student> Students { get; set; }
    }
}
