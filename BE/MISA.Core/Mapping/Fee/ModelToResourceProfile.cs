using AutoMapper;
using MISA.Core.Resources.Fee;

namespace MISA.Core.Mapping.Fee
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Entities.Fee, FeeResource>();
        }
    }
}
