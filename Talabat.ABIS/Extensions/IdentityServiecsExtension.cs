using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Talabat.Core.Entites.Identity;
using Talabat.Core.Services;
using Talabat.Repository.Identity;
using Talabat.Servicse;

namespace Talabat.ABIS.Extensions
{
    public static class IdentityServiecsExtension
    {

        public static IServiceCollection AddIdentityServies(this IServiceCollection Services, IConfiguration configuration)
        {

            Services.AddScoped<ITokenService, TokenService>();

            Services.AddIdentity<AppUser, IdentityRole>()
                   .AddEntityFrameworkStores<AppIdentityDbContext>();
            Services.AddAuthentication(Option => 
            {
                Option.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme;
                Option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


            })
                .AddJwtBearer(Options =>
                {
                    Options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = configuration["JWT:ValidIssuer"],
                        ValidateAudience = true,
                        ValidAudience = configuration["JWT,ValidAudinece"],
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))

                    };
                }

                );

            return Services;

        }



    }
}
