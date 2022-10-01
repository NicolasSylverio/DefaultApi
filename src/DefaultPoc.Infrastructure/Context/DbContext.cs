using DefaultPoc.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace DefaultPoc.Infrastructure.Context
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options) { }

        public DbSet<WeatherForecast> WeatherForecast { get; set; }
        public DbSet<Car> Car { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}