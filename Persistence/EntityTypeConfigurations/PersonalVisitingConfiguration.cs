using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ХранительПРО.Domain;

namespace Persistence.EntityTypeConfigurations
{
    public class PersonalVisitingConfiguration : IEntityTypeConfiguration<PersonVisiting>
    {
        public void Configure(EntityTypeBuilder<PersonVisiting> builder)
        {
            builder.HasKey(personalVisiting => personalVisiting.Id);
            builder.HasIndex(personalVisiting => personalVisiting.Id).IsUnique();
        }
    }
}
