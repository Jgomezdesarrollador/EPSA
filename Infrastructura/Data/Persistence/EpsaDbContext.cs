using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructura.Data.Persistence
{
    public class EpsaDbContext : DbContext
    {
        public EpsaDbContext(DbContextOptions<EpsaDbContext> options) : base(options) { }

        public DbSet<Consumo> Consumos => Set<Consumo>();
        public DbSet<Costo> Costos => Set<Costo>();
        public DbSet<Perdida> Perdidas => Set<Perdida>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
