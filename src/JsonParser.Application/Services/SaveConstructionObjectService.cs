using AutoMapper;
using JsonParser.Abstractions.Application.Interfaces;
using JsonParser.Contracts;
using JsonParser.Domain.Entity;
using JsonParser.Persistence;
using Newtonsoft.Json;

namespace JsonParser.Application.Services;

public class SaveConstructionObjectService : ISaveConstructionObjectService
{
    private readonly IParseJsonDbContext _parseJsonDbContext;
    private readonly IMapper _mapper;

    public SaveConstructionObjectService(
        IParseJsonDbContext parseJsonDbContext,
        IMapper mapper)
    {
        _parseJsonDbContext = parseJsonDbContext;
        _mapper = mapper;
    }

    public async Task SaveConstructionObjectJson(string filePath)
    {
        var json = File.ReadAllText(filePath);

        var constuctionObjectModel = JsonConvert.DeserializeObject<AddConstructionObjectDTO>(json);

        var constructionObject = _mapper.Map<ConstructionObject>(constuctionObjectModel);

        _parseJsonDbContext.ConstructionObject.Add(constructionObject);

        await _parseJsonDbContext.SaveChangesAsync();
    }
}
