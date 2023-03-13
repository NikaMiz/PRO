using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ХранительПРО.Domain;

namespace Persistence.EntityTypeConfigurations
{
    public class GroupVisitingConfiguration : IEntityTypeConfiguration<GroupVisiting>
    {
        public void Configure(EntityTypeBuilder<GroupVisiting> builder)
        {
            builder.HasKey(groupVisiting => groupVisiting.Id);
            builder.HasIndex(groupVisiting => groupVisiting.Id).IsUnique();
        }
    }
}
