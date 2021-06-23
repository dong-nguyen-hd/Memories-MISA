using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Services;
using MISA.Core.Resources.FeeRange;

namespace MISA.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FeeRangeController : BaseController<FeeRangeResource, CreateFeeRangeResource, UpdateFeeRangeResource, FeeRange>
    {
        #region Constructor
        public FeeRangeController(IFeeRangeService feeRangeService) : base(feeRangeService)
        {
        }
        #endregion
    }
}
