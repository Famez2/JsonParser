using AutoMapper;
using JsonParser.Abstractions.Application.Interfaces;
using JsonParser.Contracts;
using JsonParser.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JsonParser.Application.Services;

public class GetConstructionObjectService : IGetConstructionObjectService
{
    private readonly IParseJsonDbContext _parseJsonDbContext;
    private readonly IMapper _mapper;

    public GetConstructionObjectService(
        IParseJsonDbContext parseJsonDbContext,
        IMapper mapper)
    {
        _parseJsonDbContext = parseJsonDbContext;
        _mapper = mapper;
    }

    public async Task<GetConstructionObjectsDTO> GetConstructionObjectAsync()
    {
        var constructionObjects = await _parseJsonDbContext.ConstructionObject
            .AsNoTracking()
            .Include(x => x.Knotes)
            .Include(x => x.References)
            .Include(x => x.MessageFormats)
            .ToListAsync();

        return _mapper.Map<GetConstructionObjectsDTO>(constructionObjects);
    }
}
