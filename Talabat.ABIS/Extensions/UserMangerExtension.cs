using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entites.Identity;

namespace Talabat.ABIS.Extensions
{
    public static class UserMangerExtension
    {
        public static async Task<AppUser?> FindUserWithAddressAsync(this UserManager<AppUser> userManger, ClaimsPrincipal User)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var user =await userManger.Users.Include(U=> U.address).FirstOrDefaultAsync(U => U.Email == Email);

            return user;
        }


    }
}
