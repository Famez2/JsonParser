using JsonParser.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JsonParser.Persistence.Configuration;

public class ConstructionObjectTypeConfiguration : IEntityTypeConfiguration<ConstructionObject>
{
    public void Configure(EntityTypeBuilder<ConstructionObject> builder)
    {
        builder.ToTable(nameof(ConstructionObject));

        builder.HasKey(x => x.Id);
    }
}
