using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace MISA.Api.Controllers
{
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

        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync([FromBody] Insert entity)
        {
            var tempData = await _baseService.InsertAsync(entity);

            if (tempData.Success)
                return StatusCode(201, tempData);

            return BadRequest(tempData);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateAsync(Guid id, [FromBody] Update entity)
        {
            var tempData = await _baseService.UpdateAsync(id, entity);

            if (tempData.Success)
                return Ok(tempData);

            return BadRequest(tempData);
        }

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
