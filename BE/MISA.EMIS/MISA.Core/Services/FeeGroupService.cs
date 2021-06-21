using AutoMapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using MISA.Core.Resources.FeeGroup;

namespace MISA.Core.Services
{
    public class FeeGroupService : BaseService<FeeGroupResource, CreateFeeGroupResource, UpdateFeeGroupResource, FeeGroup>, IFeeGroupService
    {
        #region Constructor
        public FeeGroupService(IFeeGroupRepository feeGroupRepository, IMapper mapper) : base(feeGroupRepository, mapper)
        {
        }
        #endregion
    }
}
