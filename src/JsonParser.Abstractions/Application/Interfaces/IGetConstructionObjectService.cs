using JsonParser.Contracts;

namespace JsonParser.Abstractions.Application.Interfaces;

public interface IGetConstructionObjectService
{
    public Task<GetConstructionObjectsDTO> GetCompaniesAsync();
}
