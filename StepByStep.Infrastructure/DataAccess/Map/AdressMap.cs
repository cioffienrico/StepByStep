using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StepByStep.Infrastructure.DataAccess.Entities;

namespace StepByStep.Infrastructure.DataAccess.Map
{
    public class AdressMap : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.ToTable("Adress", "public");
            builder.HasKey(k => k.Id);
        }
    }
}
