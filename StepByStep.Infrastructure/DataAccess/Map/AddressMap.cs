using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StepByStep.Infrastructure.DataAccess.Entities;

namespace StepByStep.Infrastructure.DataAccess.Map
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address", "Public");
            builder.HasKey(k => k.Id);
            builder.Property(d => d.Cep).IsRequired();
            builder.Property(d => d.Neighborhood).IsRequired();
            builder.Property(d => d.Road).IsRequired();
            builder.Property(d => d.Number).IsRequired();
            builder.Property(d => d.Complement).IsRequired();
            builder.Property(d => d.City).IsRequired();
            builder.Property(d => d.State).IsRequired();

        }
    }
}
