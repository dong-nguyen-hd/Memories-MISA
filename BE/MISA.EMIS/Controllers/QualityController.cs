using Microsoft.AspNetCore.Mvc;
using MISA.Core.Data;
using MISA.Core.Extensions;
using MISA.Core.Resources;
using MISA.Core.Services.Communication;
using System;
using System.Collections.Generic;

namespace MISA.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QualityController : ControllerBase
    {
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
