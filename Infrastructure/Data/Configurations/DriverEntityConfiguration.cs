using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class DriverEntityConfiguration : IEntityTypeConfiguration<DriverEntity>
    {
        public void Configure(EntityTypeBuilder<DriverEntity> builder) 
        {
            builder.Property(x => x.Firstname)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Lastname)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
