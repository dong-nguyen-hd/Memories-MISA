using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Services;
using MISA.Core.Resources.UnitFee;

namespace MISA.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UnitFeeController : BaseController<UnitFeeResource, CreateUnitFeeResource, UpdateUnitFeeResource, UnitFee>
    {
        #region Constructor
        public UnitFeeController(IUnitFeeService unitFeeService) : base(unitFeeService)
        {
        }
        #endregion
    }
}
