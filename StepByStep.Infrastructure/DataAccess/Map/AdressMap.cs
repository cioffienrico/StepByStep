using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StepByStep.Domain;

namespace StepByStep.Infrastructure.DataAccess.Map
{
    public class AdressMap : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.ToTable("Adress", "StepByStep");
            builder.HasKey(k => k.Id);
        }
    }
}
