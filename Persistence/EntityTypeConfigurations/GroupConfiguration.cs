using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ХранительПРО.Domain;

namespace Persistence.EntityTypeConfigurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<InfoGroup>
    {
        public void Configure(EntityTypeBuilder<InfoGroup> builder)
        {
            builder.HasKey(group => group.Id);
            builder.HasIndex(group => group.Id).IsUnique();
        }
    }
}
