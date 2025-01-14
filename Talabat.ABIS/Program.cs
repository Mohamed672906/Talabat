using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using Talabat.ABIS.Errors;
using Talabat.ABIS.Extensions;
using Talabat.ABIS.Helpers;
using Talabat.ABIS.Middelwares;
using Talabat.Core.Entites;
using Talabat.Core.Repositories;
using Talabat.Repository;
using Talabat.Repository.Data;
using Talabat.Repository.Identity;

namespace Talabat.ABIS
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Configer Services

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<StoreContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddApplictionServiecs();
            builder.Services.AddSingleton<IConnectionMultiplexer>(Options =>
            {
                var Connection = builder.Configuration.GetConnectionString("RedisConnection");
                return ConnectionMultiplexer.Connect(Connection);
            });

            //---

            builder.Services.AddDbContext<AppIdentityDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });






            #endregion


            using var app = builder.Build();


            #region Update-Database

            var Scope = app.Services.CreateScope();

            var Services = Scope.ServiceProvider;

            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();

            try
            {

                var dbContext = Services.GetRequiredService<StoreContext>();
                await dbContext.Database.MigrateAsync();



                var AppIdentityDbContext = Services.GetRequiredService<AppIdentityDbContext>();
                await AppIdentityDbContext.Database.MigrateAsync();



                await StoreContextSeed.SeedAsync(dbContext);


            }
            catch (Exception ex)
            {
                var Logger = LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex, "An Error Occured During Appling The Migration");
            }

            #endregion



            #region Configure

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMiddleware<ExpestionMiddelwares>();
                app.UseSwagerMiddelwares();
            }

            app.UseStatusCodePagesWithRedirects("/error/{0}");
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            #endregion


            app.Run();

        }
    }
}
