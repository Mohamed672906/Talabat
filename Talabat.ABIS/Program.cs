using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Talabat.ABIS.Errors;
using Talabat.ABIS.Helpers;
using Talabat.ABIS.Middelwares;
using Talabat.Core.Entites;
using Talabat.Core.Repositories;
using Talabat.Repository;
using Talabat.Repository.Data;

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
            builder.Services.AddDbContext<StoreContext>(option=>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            //  builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            //builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));
            builder.Services.AddAutoMapper(typeof(MappingProfiles));
            builder.Services.Configure<ApiBehaviorOptions>(options =>
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


            using var app = builder.Build();


            #region Update-Database

            var Scope = app.Services.CreateScope();

            var Services = Scope.ServiceProvider;

            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();
                        
           try
            {

            var dbContext = Services.GetRequiredService<StoreContext>();

           await dbContext.Database.MigrateAsync();
           await StoreContextSeed.SeedAsync(dbContext);

            }
            catch (Exception ex)
            {
                var Logger = LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex,"An Error Occured During Appling The Migration");
            }



            #endregion

            

            #region Configure

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMiddleware<ExpestionMiddelwares>();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers(); 
            #endregion


            app.Run();
        }
    }
}
