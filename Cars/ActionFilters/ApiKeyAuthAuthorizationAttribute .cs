using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Cars.ActionFilters
{
    public class ApiKeyAuthAuthorizationAttribute :Attribute, IAsyncAuthorizationFilter
    {
      
      private const string ApiKeyHeaderName = "apiKey";

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var potentialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
            var apiKey = configuration.GetValue<string>("ApiKey");

            if (!apiKey.Equals(potentialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

        }
    }
}
