using AutoMapper;
using MISA.Core.Extensions;
using MISA.Core.Resources.FeeGroup;
using System;

namespace MISA.Core.Mapping.FeeGroupGroup
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CreateFeeGroupResource, Entities.FeeGroup>()
                .ForMember(x => x.FeeGroupName, opt => opt.MapFrom(src => src.FeeGroupName.RemoveSpaceCharacter()))
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => "NDDONG"))
                .ForMember(x => x.FeeGroupId, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<FeeGroupResource, Entities.FeeGroup>()
                .ForMember(x => x.FeeGroupName, opt => opt.MapFrom(src => src.FeeGroupName.RemoveSpaceCharacter()));

            CreateMap<UpdateFeeGroupResource, Entities.FeeGroup>()
                .ForMember(x => x.FeeGroupName, opt => opt.MapFrom(src => src.FeeGroupName.RemoveSpaceCharacter()))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
