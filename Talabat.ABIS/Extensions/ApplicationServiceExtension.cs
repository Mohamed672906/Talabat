using Microsoft.AspNetCore.Mvc;
using Talabat.ABIS.Errors;
using Talabat.ABIS.Helpers;
using Talabat.Core;
using Talabat.Core.Repositories;
using Talabat.Repository;

namespace Talabat.ABIS.Extensions
{
    public static class ApplicationServiceExtension
    {

        public static IServiceCollection AddApplictionServiecs(this IServiceCollection Services)
        {

            Services.AddScoped<IBaskedReopsitory, BasketRepostiory>();

            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            Services.AddAutoMapper(typeof(MappingProfiles));

            #region Error Handling
            Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(P => P.Value.Errors.Count > 0)
                                              .SelectMany(P => P.Value.Errors)
                                              .Select(E => E.ErrorMessage)
                                              .ToArray();
                    var ValidationErrprResponce = new ApiValidationErrorResponce()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(ValidationErrprResponce);
                };
            });

            #endregion

            Services.AddScoped<IUnitOfWork, UnitOfWork>();

            return Services;
        }








    }
}
