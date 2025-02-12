using JsonParser.Abstractions.Persistence.Interfaces;
using JsonParser.Domain.Entit;
using JsonParser.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace JsonParser.Persistence;

public interface IParseJsonDbContext : IDbContext
{
    public DbSet<ConstructionObject> ConstructionObject { get; set; }

    public DbSet<Knot> Knot { get; set; }

    public DbSet<Reference> Reference { get; set; }

    public DbSet<MessageFormat> MessageFormat { get; set; }
}
