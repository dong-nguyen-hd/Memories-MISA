using AutoMapper;
using MISA.Core.Resources.FeeGroup;

namespace MISA.Core.Mapping.FeeGroup
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Entities.FeeGroup, FeeGroupResource>();
        }
    }
}
