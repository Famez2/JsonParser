using JsonParser.Domain.Entit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JsonParser.Persistence.Configuration;

public class KnotTypeConfiguration : IEntityTypeConfiguration<Knot>
{
    public void Configure(EntityTypeBuilder<Knot> builder)
    {
        builder.ToTable(nameof(Knot));

        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Reference)
            .WithMany(x => x.Knotes)
            .HasForeignKey(x => x.ReferenceId);
    }
}
