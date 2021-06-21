using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace MISA.Api.Controllers.Configuration
{
    /// <summary>
    /// Lớp tuỳ biến parameter của endpoint
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    class QueryStringModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (result == ValueProviderResult.None)
            {
                // Parameter is missing, interpret as string-empty
                bindingContext.Result = ModelBindingResult.Success(string.Empty);
            }
            else
            {
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, result);
                var rawValue = result.FirstValue;
                if (string.IsNullOrEmpty(rawValue.Trim()))
                {
                    // Value is empty, interpret as string-empty
                    bindingContext.Result = ModelBindingResult.Success(string.Empty);
                }
                else
                {
                    // Value is a valid string type, use that value
                    bindingContext.Result = ModelBindingResult.Success(rawValue.ToString());
                }
            }

            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// Lớp tuỳ biến parameter của endpoint
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    class QueryStringModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(string) &&
            context.BindingInfo.BindingSource != null &&
            context.BindingInfo.BindingSource.CanAcceptDataFrom(BindingSource.Query))
            {
                return new QueryStringModelBinder();
            }

            return null;
        }
    }
}
