using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Talabat.Core.Entites.Identity;
using Talabat.Core.Services;
using Talabat.Repository.Identity;
using Talabat.Servicse;

namespace Talabat.ABIS.Extensions
{
    public static class IdentityServiecsExtension
    {

        public static IServiceCollection AddIdentityServies(this IServiceCollection Services)
        {

            Services.AddScoped<ITokenService, TokenService>();  

            Services.AddIdentity<AppUser, IdentityRole>()
                   .AddEntityFrameworkStores<AppIdentityDbContext>();
            Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(); //UserManger - SigninManger - RoleManger

            return Services;

        }



    }
}
