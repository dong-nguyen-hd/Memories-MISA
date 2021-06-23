using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Services;
using MISA.Core.Resources.FeeGroup;

namespace MISA.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FeeGroupController : BaseController<FeeGroupResource, CreateFeeGroupResource, UpdateFeeGroupResource, FeeGroup>
    {
       #region Constructor
        public FeeGroupController(IFeeGroupService feeGroupService) : base(feeGroupService)
        {
        }
        #endregion
    }
}
