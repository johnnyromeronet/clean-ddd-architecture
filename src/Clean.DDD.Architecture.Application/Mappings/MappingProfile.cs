using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Clean.DDD.Architecture.Domain.Entities.Base;
using Clean.DDD.Architecture.Domain.Models.Base;

namespace Clean.DDD.Architecture.Application.Mappings
{
    [ExcludeFromCodeCoverage]
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseEntity, BaseModel>()
                .ReverseMap();
        }
    }
}
