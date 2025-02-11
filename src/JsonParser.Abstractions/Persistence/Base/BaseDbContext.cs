using Microsoft.EntityFrameworkCore;

namespace JsonParser.Abstractions.Persistence.Base;

public abstract class BaseDbContext : DbContext
{
    protected BaseDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureModelBuilder(modelBuilder);
    }

    protected virtual void ConfigureModelBuilder(ModelBuilder modelBuilder)
    {
    }
}
