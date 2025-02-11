using JsonParser.Domain.Entity;

namespace JsonParser.Abstractions.Application.Interfaces;

public interface IGetParseJsonService
{
    public Task<List<Company>> GetCompaniesAsync();
}
