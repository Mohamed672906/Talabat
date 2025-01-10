using System.Text.Json;
using Talabat.ABIS.Errors;

namespace Talabat.ABIS.Middelwares
{
    public class ExpestionMiddelwares
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExpestionMiddelwares> _logger;
        private readonly IHostEnvironment _env;

        public ExpestionMiddelwares(RequestDelegate Next , ILogger<ExpestionMiddelwares>logger , IHostEnvironment env)
        {
            _next = Next;
            _logger = logger;
            _env = env;
        }


        //InvokeAsync

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                //if (_env.IsDevelopment())
                //{
                //    var Response = new ApiExpestionResponse(500, ex.Message, ex.StackTrace.ToString());
                //}
                //else
                //{

                //    var Response = new ApiExpestionResponse(500);
                //}
                var Response = _env.IsDevelopment() ? new ApiExpestionResponse(500, ex.Message, ex.StackTrace.ToString()) : new ApiExpestionResponse(500);
                var Option = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var jasonResponse = JsonSerializer.Serialize(Response , Option);
                context.Response.WriteAsync(jasonResponse);




















































            }

        }








    }
}
