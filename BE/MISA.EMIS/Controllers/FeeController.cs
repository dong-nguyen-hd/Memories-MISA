using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Services;
using MISA.Core.Resources;
using MISA.Core.Resources.Fee;
using System.Threading.Tasks;

namespace MISA.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FeeController : BaseController<FeeResource, CreateFeeResource, UpdateFeeResource, Fee>
    {
        #region Property
        private readonly IFeeService _feeService;
        #endregion

        #region Constructor
        public FeeController(IFeeService feeService) : base(feeService)
        {
            this._feeService = feeService;
        }
        #endregion

        #region Method
        [HttpPost("delete")]
        public async Task<IActionResult> CreateAsync([FromBody] DeleteResource resource)
        {
            var tempData = await _feeService.DeleteManyAsync(resource);

            if (tempData.Success)
                return Ok(tempData);

            return BadRequest(tempData);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override async Task<IActionResult> GetAllAsync()
        {
            return NotFound(new ResultResource("Action bị xoá"));
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> GetAllAsync([FromBody] SearchFeeResource resourceSearch)
        {
            var tempData = await _feeService.GetAllPaginationAsync(resourceSearch);

            if (!tempData.Success)
                return BadRequest(tempData);

            if (!tempData.Resource.GetEnumerator().MoveNext())
                return NoContent();

            return Ok(tempData);
        }
        #endregion
    }
}
