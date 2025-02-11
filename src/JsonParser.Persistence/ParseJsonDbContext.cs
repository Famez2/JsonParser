using DotNetEnv;
using JsonParser.Abstractions.Persistence.Base;
using JsonParser.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JsonParser.Persistence;

public class ParseJsonDbContext : BaseDbContext, IParseJsonDbContext
{
    public DbSet<Company> Company { get; set; }

    public ParseJsonDbContext(DbContextOptions<ParseJsonDbContext> options)
        : base(options)
    {
    }

    public ParseJsonDbContext() : base(new DbContextOptions<ParseJsonDbContext>())
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            Env.Load();

            var connectionString = Env.GetString("DATABASE_CONNECTION");

            optionsBuilder.UseSqlite(connectionString);
        }
    }

    protected override void ConfigureModelBuilder(ModelBuilder modelBuilder)
    {
        base.ConfigureModelBuilder(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
