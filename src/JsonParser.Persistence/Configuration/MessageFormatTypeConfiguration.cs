using JsonParser.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JsonParser.Persistence.Configuration;

public class MessageFormatTypeConfiguration : IEntityTypeConfiguration<MessageFormat>
{
    public void Configure(EntityTypeBuilder<MessageFormat> builder)
    {
        builder.ToTable("Message");

        builder.HasKey(x => x.Id);
    }
}
