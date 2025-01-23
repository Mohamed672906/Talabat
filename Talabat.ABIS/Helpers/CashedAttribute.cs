using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Talabat.Core.Service;

namespace Talabat.ABIS.Helpers
{
    public class CashedAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _expierTimeInSeconds;

        public CashedAttribute(int ExpierTimeInSeconds)
        {
            _expierTimeInSeconds = ExpierTimeInSeconds;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var casheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCashService>();

            var CacheKey = GenertCasheKeyFromRequest(context.HttpContext.Request);


            var CashResponse = await casheService.GetCashResopnse(CacheKey);
            if (!string.IsNullOrEmpty(CashResponse))
            {
                var contentResult = new ContentResult()
                {
                    Content = CashResponse,
                    ContentType = "application/json",
                    StatusCode = 200,
                };
                context.Result = contentResult;
                return;
            }

            var ExcutedEndPointContxt = await next.Invoke();

            if (ExcutedEndPointContxt.Result is OkObjectResult result)
            {
                await casheService.CasheResponseAsync(CacheKey , result.Value , TimeSpan.FromSeconds(_expierTimeInSeconds)); 
            }

        }

        private string GenertCasheKeyFromRequest(HttpRequest request)
        {
            var KeyBuilder = new StringBuilder();
            KeyBuilder.Append(request.Path);

            foreach (var (Key, valu) in request.Query.OrderBy(x => x.Key))
            {
                KeyBuilder.Append($"|{Key}-{valu}");
            }

            return KeyBuilder.ToString();
        }
    }
}
