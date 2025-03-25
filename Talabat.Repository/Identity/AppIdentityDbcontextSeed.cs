using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Talabat.Core.Entites.Identity;

namespace Talabat.Repository.Identity
{
    public static class AppIdentityDbcontextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {

                var User = new AppUser()
                {
                    DisplayName = "Mohamed Ali",
                    Email = "mohamedAli@gmail.com",
                    UserName = "MohamedAli",
                    PhoneNumber = "01098424599",

                };

                await userManager.CreateAsync(User, "Pa$$W0rd");

            };


        }






    }
}
