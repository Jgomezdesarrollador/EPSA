using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructura.Data.Configurations
{
    public class PerdidaConfiguration : IEntityTypeConfiguration<Perdida>
    {
        public void Configure(EntityTypeBuilder<Perdida> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Tramo).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Fecha).IsRequired();
            builder.Property(e => e.ResidencialPorcentaje).IsRequired();
            builder.Property(e => e.ComercialPorcentaje).IsRequired();
            builder.Property(e => e.IndustrialPorcentaje).IsRequired();
        }
    }
}
