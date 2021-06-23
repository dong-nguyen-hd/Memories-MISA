using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MISA.Core.Interfaces.Services;
using MISA.Core.Resources;
using System;
using System.Threading.Tasks;

namespace MISA.Api.Controllers
{
    /// <summary>
    /// Lớp base giúp các controller khác kế thừa
    /// </summary>
    /// <typeparam name="Response">Kiểu dữ liệu trả về</typeparam>
    /// <typeparam name="Insert">Kiểu dữ liệu Thêm mới</typeparam>
    /// <typeparam name="Update">Kiểu dữ liệu Cập nhật</typeparam>
    /// <typeparam name="Entity">Kiểu dữ liệu Entity class</typeparam>
    /// CreatedBy: NDDONG (12/06/2021)
    [ApiController]
    public class BaseController<Response, Insert, Update, Entity> : ControllerBase
    {
        #region Property
        private readonly IBaseService<Response, Insert, Update, Entity> _baseService;
        #endregion

        #region Constructor
        public BaseController(IBaseService<Response, Insert, Update, Entity> baseService)
        {
            this._baseService = baseService;
        }
        #endregion

        #region Method
        /// <summary>
        /// Phương thức GET: lấy ra tất cả dữ liệu
        /// </summary>
        /// <returns>Status code: 200 khi thành công và có dữ liệu, 
        /// Status code: 204 khi thành công và không có dữ liệu, 
        /// Status code: 400 khi request thất bại
        /// </returns>
        /// CreatedBy: NDDONG (12/06/2021)
        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            var tempData = await _baseService.GetAllAsync();

            if (!tempData.Success)
                return BadRequest(tempData);

            if (tempData.Resource is null)
                return NoContent();

            return Ok(tempData);
        }

        /// <summary>
        /// Phương thức GET: lấy ra dữ liệu theo Id
        /// </summary>
        /// <param name="id">Id của đối tượng</param>
        /// <returns>Status code: 200 khi thành công và có dữ liệu, 
        /// Status code: 204 khi thành công và không có dữ liệu, 
        /// Status code: 400 khi request thất bại
        /// </returns>
        /// CreatedBy: NDDONG (12/06/2021)
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var tempData = await _baseService.GetByIdAsync(id);

            if (!tempData.Success)
                return BadRequest(tempData);

            if (tempData.Resource is null)
                return NoContent();

            return Ok(tempData);
        }

        /// <summary>
        /// Phương thức POST: tạo mới dữ liệu
        /// </summary>
        /// <returns>Status code: 201 tạo mới thành công, 
        /// Status code: 400 khi request thất bại
        /// </returns>
        /// CreatedBy: NDDONG (12/06/2021)
        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync([FromBody] Insert entity)
        {
            var tempData = await _baseService.InsertAsync(entity);

            if (tempData.Success)
                return StatusCode(201, tempData);

            return BadRequest(tempData);
        }

        /// <summary>
        /// Phương thức PUT: lấy ra tất cả dữ liệu
        /// </summary>
        /// <returns>Status code: 200 khi thành công và có dữ liệu, 
        /// Status code: 204 khi thành công và không có dữ liệu, 
        /// Status code: 400 khi request thất bại
        /// </returns>
        /// CreatedBy: NDDONG (12/06/2021)
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateAsync(Guid id, [FromBody] Update entity)
        {
            var tempData = await _baseService.UpdateAsync(id, entity);

            if (tempData.Success)
                return Ok(tempData);

            return BadRequest(tempData);
        }

        /// <summary>
        /// Phương thức DELETE: xoá dữ liệu theo Id
        /// </summary>
        /// <param name="id">Id của đối tượng muốn xoá</param>
        /// <returns>Status code: 200 khi thành công, 
        /// Status code: 400 khi request thất bại
        /// </returns>
        /// CreatedBy: NDDONG (14/06/2021)
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(Guid id)
        {
            var tempData = await _baseService.DeleteAsync(id);

            if (tempData.Success)
                return Ok(tempData);

            return BadRequest(tempData);
        }
        #endregion
    }
}
