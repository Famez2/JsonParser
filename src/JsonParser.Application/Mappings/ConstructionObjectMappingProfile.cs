using AutoMapper;
using JsonParser.Contracts;
using JsonParser.Domain.Entit;
using JsonParser.Domain.Entity;

namespace JsonParser.Application.Mappings;

public class ConstructionObjectMappingProfile : Profile
{
    public ConstructionObjectMappingProfile()
    {
        CreateMap<AddConstructionObjectDTO, ConstructionObject>()
            .ForMember(dest => dest.References, opt => opt.MapFrom(src => new List<Reference> { new Reference
            {
                Id = src.Reference.Id,
                Group = src.Reference.Group,
                Name = src.Reference.Name,
                Method = src.Reference.Method,
                ObjectId = src.Id
            }}))
            .ForMember(dest => dest.Knotes, opt => opt.MapFrom(src => new List<Knot> { new Knot
            {
                Code = src.Knot.Code,
                ObjectId = src.Id,
                Reference = new Reference
                {
                    Id = src.Knot.Reference.Id,
                    Group = src.Knot.Reference.Group,
                    Name = src.Knot.Reference.Name,
                    Method = src.Knot.Reference.Method,
                    ObjectId = src.Id
                }
            }}))
            .ForMember(dest => dest.MessageFormats, opt => opt.MapFrom(src => new List<MessageFormat> { new MessageFormat
            {
                Group = src.MessageFormat.Group,
                Name = src.MessageFormat.Name,
                Value = src.MessageFormat.Value,
                ObjectId = src.Id,
            }}));
    }
}
