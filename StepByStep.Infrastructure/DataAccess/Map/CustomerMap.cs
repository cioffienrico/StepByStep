using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StepByStep.Infrastructure.DataAccess.Entities;

namespace StepByStep.Infrastructure.DataAccess.Map
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "StepByStep");
            builder.HasKey(s => s.Id);
            builder.Property(d => d.Name).IsRequired().HasMaxLength(200);
            builder.Property(d => d.Birthday).IsRequired();
            builder.Property(d => d.Rg).HasMaxLength(100);
            builder.Property(d => d.Cpf).HasMaxLength(100);
        }
    }
}
