using AutoMapper;
using MISA.Core.Resources.FeeRange;

namespace MISA.Core.Mapping.FeeRange
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Entities.FeeRange, FeeRangeResource>();
        }
    }
}
