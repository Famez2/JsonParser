using JsonParser.Abstractions.Application.Interfaces;
using JsonParser.Domain.Entity;
using JsonParser.Persistence;
using Newtonsoft.Json;

namespace JsonParser.Application.Services;

public class SaveParseJsonService : ISaveParseJsonService
{
    private readonly IParseJsonDbContext _parseJsonDbContext;

    public SaveParseJsonService(IParseJsonDbContext parseJsonDbContext)
    {
        _parseJsonDbContext = parseJsonDbContext;
    }

    public async Task ParseJson(
        string filePath)
    {
        var json = File.ReadAllText(filePath);

        await _parseJsonDbContext.SaveChangesAsync();
    }
}
