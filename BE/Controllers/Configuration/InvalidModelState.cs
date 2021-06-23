using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MISA.Core.Resources;
using System.Collections.Generic;
using System.Linq;

namespace MISA.Api.Controllers.Configuration
{
    /// <summary>
    /// Lớp tĩnh giúp tuỳ biến JSON trả về
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public static class InvalidModelState
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.GetErrorMessages();
            var response = new ResultResource(messages: errors);

            return new BadRequestObjectResult(response);
        }

        private static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            var tempData = dictionary.SelectMany(m => m.Value.Errors)
                             .Select(m => m.ErrorMessage)
                             .ToList();

            // It disable for debug-enviroment
            if ((bool)tempData?[0].Contains("The JSON value could not be converted"))
            {
                tempData[0] = "Kiểu dữ liệu không hợp lệ (The JSON value could not be converted)";
            }

            return tempData;
        }
    }
}
