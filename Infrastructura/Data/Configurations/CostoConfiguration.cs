using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructura.Data.Configurations
{
    public class CostoConfiguration : IEntityTypeConfiguration<Costo>
    {
        public void Configure(EntityTypeBuilder<Costo> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Tramo).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Fecha).IsRequired();
            builder.Property(e => e.ResidencialCosto).IsRequired();
            builder.Property(e => e.ComercialCosto).IsRequired();
            builder.Property(e => e.IndustrialCosto).IsRequired();
        }
    }
}
