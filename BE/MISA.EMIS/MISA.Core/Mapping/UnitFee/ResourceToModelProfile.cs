using AutoMapper;
using MISA.Core.Extensions;
using MISA.Core.Resources.UnitFee;
using System;

namespace MISA.Core.Mapping.UnitUnitFee
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CreateUnitFeeResource, Entities.UnitFee>()
                .ForMember(x => x.UnitFeeName, opt => opt.MapFrom(src => src.UnitFeeName.RemoveSpaceCharacter()))
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => "NDDONG"))
                .ForMember(x => x.UnitFeeId, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<UnitFeeResource, Entities.UnitFee>()
                .ForMember(x => x.UnitFeeName, opt => opt.MapFrom(src => src.UnitFeeName.RemoveSpaceCharacter()));

            CreateMap<UpdateUnitFeeResource, Entities.UnitFee>()
                .ForMember(x => x.UnitFeeName, opt => opt.MapFrom(src => src.UnitFeeName.RemoveSpaceCharacter()))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
