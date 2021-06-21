using AutoMapper;
using MISA.Core.Resources.UnitFee;

namespace MISA.Core.Mapping.UnitUnitFee
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Entities.UnitFee, UnitFeeResource>();
        }
    }
}
