using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructura.Data.Configurations
{
    public class ConsumoConfiguration : IEntityTypeConfiguration<Consumo>
    {
        public void Configure(EntityTypeBuilder<Consumo> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Tramo).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Fecha).IsRequired();
            builder.Property(e => e.ResidencialWh).IsRequired();
            builder.Property(e => e.ComercialWh).IsRequired();
            builder.Property(e => e.IndustrialWh).IsRequired();
        }
    }
}
