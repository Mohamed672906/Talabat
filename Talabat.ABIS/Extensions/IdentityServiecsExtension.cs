using Microsoft.AspNetCore.Identity;
using Talabat.Core.Entites.Identity;
using Talabat.Repository.Identity;

namespace Talabat.ABIS.Extensions
{
    public static class IdentityServiecsExtension
    {

        public static IServiceCollection AddIdentityServies(this IServiceCollection Services)
        {

            Services.AddIdentity<AppUser, IdentityRole>()
                   .AddEntityFrameworkStores<AppIdentityDbContext>();
            Services.AddAuthentication(); //UserManger - SigninManger - RoleManger

            return Services;

        }



    }
}
