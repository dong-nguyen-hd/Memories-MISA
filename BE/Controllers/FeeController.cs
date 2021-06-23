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
        /// <summary>
        /// Phương thức POST: xoá dữ liệu theo mảng Id
        /// </summary>
        /// <param name="resource">Mảng các Id muốn xoá</param>
        /// <returns>Status code: 200 khi thành công, 
        /// Status code: 400 khi request thất bại
        /// </returns>
        /// CreatedBy: NDDONG (14/06/2021)
        [HttpPost("delete")]
        public async Task<IActionResult> CreateAsync([FromBody] DeleteResource resource)
        {
            var tempData = await _feeService.DeleteManyAsync(resource);

            if (tempData.Success)
                return Ok(tempData);

            return BadRequest(tempData);
        }

        /// <summary>
        /// Phương thức ngừng sử dụng ở v1
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NDDONG (14/06/2021)
        [ApiExplorerSettings(IgnoreApi = true)]
        public override async Task<IActionResult> GetAllAsync()
        {
            return NotFound(new ResultResource("Action bị xoá"));
        }

        /// <summary>
        /// Phương thức POST: lấy dữ liệu, kết hợp phân trang, lọc, và tìm kiếm.
        /// </summary>
        /// <param name="resourceSearch">Dữ liệu cần lọc, tìm kiếm</param>
        /// <returns>Status code: 200 khi thành công, 
        /// Status code: 204 khi thành công và không có dữ liệu, 
        /// Status code: 400 khi request thất bại
        /// </returns>
        /// CreatedBy: NDDONG (14/06/2021)
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
