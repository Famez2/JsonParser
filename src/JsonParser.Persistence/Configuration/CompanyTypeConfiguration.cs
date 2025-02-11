using JsonParser.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace JsonParser.Persistence.Configuration;

public class CompanyTypeConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("company");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Address)
            .IsRequired(false)
            .HasColumnName("address");

        builder.Property(c => c.Name)
            .IsRequired(false)
            .HasColumnName("name");

        builder.Property(c => c.RegistrationDate)
            .IsRequired(false)
            .HasColumnName("registration_date");

        builder.Property(c => c.Phone)
            .IsRequired(false)
            .HasColumnName("phone");
    }
}
