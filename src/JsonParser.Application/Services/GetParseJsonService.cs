using JsonParser.Abstractions.Application.Interfaces;
using JsonParser.Domain.Entity;
using JsonParser.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JsonParser.Application.Services;

public class GetParseJsonService : IGetParseJsonService
{
    private readonly IParseJsonDbContext _parseJsonDbContext;

    public GetParseJsonService(IParseJsonDbContext parseJsonDbContext)
    {
        _parseJsonDbContext = parseJsonDbContext;
    }

    public async Task GetCompaniesAsync()
    {
        //return await _parseJsonDbContext.Company.ToListAsync();
    }
}
