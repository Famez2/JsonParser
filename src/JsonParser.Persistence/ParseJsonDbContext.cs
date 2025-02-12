using DotNetEnv;
using JsonParser.Abstractions.Persistence.Base;
using JsonParser.Domain.Entit;
using JsonParser.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JsonParser.Persistence;

public class ParseJsonDbContext : BaseDbContext, IParseJsonDbContext
{
    public DbSet<ConstructionObject> ConstructionObject { get; set; }

    public DbSet<Knot> Knot { get; set; }

    public DbSet<Reference> Reference { get; set; }

    public DbSet<MessageFormat> MessageFormat { get; set; }


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
            optionsBuilder.UseSqlite("Data Source = objects.db");
        }
    }

    protected override void ConfigureModelBuilder(ModelBuilder modelBuilder)
    {
        base.ConfigureModelBuilder(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
