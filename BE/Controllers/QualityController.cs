using Microsoft.AspNetCore.Mvc;
using MISA.Core.Data;
using MISA.Core.Extensions;
using MISA.Core.Resources;
using MISA.Core.Services.Communication;
using System;
using System.Collections.Generic;

namespace MISA.Api.Controllers
{
    /// <summary>
    /// Controller của Quality
    /// CreatedBy: NDDONG (14/06/2021)
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QualityController : ControllerBase
    {
        /// <summary>
        /// Phương thức GET: lấy ra tất cả dữ liệu của Quality
        /// </summary>
        /// <returns>Status code: 200 khi thành công và có dữ liệu, 
        /// Status code: 204 khi thành công và không có dữ liệu, 
        /// </returns>
        /// CreatedBy: NDDONG (12/06/2021)
        [HttpGet]
        public IActionResult GetAllAsync()
        {
            List<QualityResource> tempData = new List<QualityResource>();

            foreach (byte item in Enum.GetValues(typeof(eQuality)))
            {
                tempData.Add(new QualityResource(item, ((eQuality)item).ToDescriptionString()));
            }

            if (tempData.Count == 0)
                return NoContent();

            return Ok(new BaseResponse<IEnumerable<QualityResource>>(tempData));
        }
    }
}
