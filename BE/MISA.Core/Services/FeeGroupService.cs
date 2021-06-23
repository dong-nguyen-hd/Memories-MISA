using AutoMapper;
using Microsoft.Extensions.Options;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using MISA.Core.Resources;
using MISA.Core.Resources.FeeGroup;

namespace MISA.Core.Services
{
    public class FeeGroupService : BaseService<FeeGroupResource, CreateFeeGroupResource, UpdateFeeGroupResource, FeeGroup>, IFeeGroupService
    {
        #region Constructor
        public FeeGroupService(IFeeGroupRepository feeGroupRepository, IMapper mapper, IOptionsSnapshot<ResponseMessage> responseMessage) : base(feeGroupRepository, mapper, responseMessage)
        {
        }
        #endregion
    }
}
