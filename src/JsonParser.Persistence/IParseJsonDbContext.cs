using JsonParser.Abstractions.Persistence.Interfaces;
using JsonParser.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace JsonParser.Persistence;

public interface IParseJsonDbContext : IDbContext
{
    public DbSet<Company> Company { get; set; }
}
