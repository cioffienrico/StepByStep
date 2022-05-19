using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StepByStep.Infrastructure.DataAccess.Entities;

namespace StepByStep.Infrastructure.DataAccess.Map
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "Public");
            builder.HasKey(k => k.Id);
            builder.HasOne(c => c.Address).WithOne(a => a.Customer).HasForeignKey<Address>(c => c.CustomerId);
            builder.Property(d => d.Name).IsRequired();
            builder.Property(d => d.Birthday).IsRequired();
            builder.Property(d => d.Cpf).IsRequired();
            builder.Property(d => d.Rg).IsRequired();
            builder.Property(d => d.RegisterDate).IsRequired();
            builder.Property(d => d.Active).IsRequired();
        }
    }
}
