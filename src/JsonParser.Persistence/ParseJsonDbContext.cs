using JsonParser.Abstractions.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JsonParser.Persistence;

public class ParseJsonDbContext : BaseDbContext
{
    public ParseJsonDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void ConfigureModelBuilder(ModelBuilder modelBuilder)
    {
        base.ConfigureModelBuilder(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
