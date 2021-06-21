using AutoMapper;
using MISA.Core.Extensions;
using MISA.Core.Resources.FeeRange;
using System;

namespace MISA.Core.Mapping.FeeRangeRange
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CreateFeeRangeResource, Entities.FeeRange>()
                .ForMember(x => x.FeeRangeName, opt => opt.MapFrom(src => src.FeeRangeName.RemoveSpaceCharacter()))
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => "NDDONG"))
                .ForMember(x => x.FeeRangeId, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<FeeRangeResource, Entities.FeeRange>()
                .ForMember(x => x.FeeRangeName, opt => opt.MapFrom(src => src.FeeRangeName.RemoveSpaceCharacter()));

            CreateMap<UpdateFeeRangeResource, Entities.FeeRange>()
                .ForMember(x => x.FeeRangeName, opt => opt.MapFrom(src => src.FeeRangeName.RemoveSpaceCharacter()))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
