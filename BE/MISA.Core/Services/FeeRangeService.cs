using AutoMapper;
using Microsoft.Extensions.Options;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using MISA.Core.Resources;
using MISA.Core.Resources.FeeRange;

namespace MISA.Core.Services
{
    public class FeeRangeService : BaseService<FeeRangeResource, CreateFeeRangeResource, UpdateFeeRangeResource, FeeRange>, IFeeRangeService
    {
        #region Constructor
        public FeeRangeService(IFeeRangeRepository feeRangeRepository, IMapper mapper, IOptionsSnapshot<ResponseMessage> responseMessage) : base(feeRangeRepository, mapper, responseMessage)
        {
        }
        #endregion
    }
}
