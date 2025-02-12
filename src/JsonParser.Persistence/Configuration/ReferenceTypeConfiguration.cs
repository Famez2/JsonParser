using JsonParser.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JsonParser.Persistence.Configuration;

public class ReferenceTypeConfiguration : IEntityTypeConfiguration<Reference>
{
    public void Configure(EntityTypeBuilder<Reference> builder)
    {
        builder.ToTable(nameof(Reference));

        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.ConstructionObject)
            .WithMany(x => x.References)
            .HasForeignKey(x => x.ObjectId);
    }
}
