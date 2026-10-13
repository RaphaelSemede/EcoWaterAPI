using Microsoft.EntityFrameworkCore;
using EcoWater.API.Models;

namespace EcoWater.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<ConsumoAgua> Consumos => Set<ConsumoAgua>();

    public DbSet<Sensor> Sensores => Set<Sensor>();

    public DbSet<Alerta> Alertas => Set<Alerta>();
}