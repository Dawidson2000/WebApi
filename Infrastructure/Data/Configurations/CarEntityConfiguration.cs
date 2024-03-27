using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.Property(x => x.Brand)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Model)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Year)
                .IsRequired();
        }
    }
}
