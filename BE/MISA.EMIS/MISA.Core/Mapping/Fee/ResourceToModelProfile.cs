using AutoMapper;
using MISA.Core.Extensions;
using MISA.Core.Resources.Fee;
using System;

namespace MISA.Core.Mapping.Fee
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CreateFeeResource, Entities.Fee>()
                .ForMember(x => x.FeeName, opt => opt.MapFrom(src => src.FeeName.RemoveSpaceCharacter()))
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => "NDDONG"))
                .ForMember(x => x.FeeId, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<FeeResource, Entities.Fee>()
                .ForMember(x => x.FeeName, opt => opt.MapFrom(src => src.FeeName.RemoveSpaceCharacter()));

            CreateMap<UpdateFeeResource, Entities.Fee>()
                .ForMember(x => x.FeeName, opt => opt.MapFrom(src => src.FeeName.RemoveSpaceCharacter()))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
