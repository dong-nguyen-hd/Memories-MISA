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
    public class TurnFeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllAsync()
        {
            List<TurnFeeResource> tempData = new List<TurnFeeResource>();

            foreach (byte item in Enum.GetValues(typeof(eTurnFee)))
            {
                tempData.Add(new TurnFeeResource(item, ((eTurnFee)item).ToDescriptionString()));
            }

            if (tempData.Count == 0)
                return NoContent();

            return Ok(new BaseResponse<IEnumerable<TurnFeeResource>>(tempData));
        }
    }
}
