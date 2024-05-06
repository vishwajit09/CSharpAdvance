using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cars.ActionFilters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        private const string _apiKey = "ApiKey";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(!context.HttpContext.Request.Headers.TryGetValue(_apiKey, out var potentialKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var configration = context.HttpContext.RequestServices.GetService<IConfiguration>();
            var apiKey = configration.GetValue<string>("ApiKey");

            if(apiKey != potentialKey) {
            
                context.Result = new UnauthorizedResult(); return;
            }
            await next();

        }
    }

    
}
