using GenericMediatRFeatures.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericMediatRFeatures.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
}