namespace Talabat.ABIS.Extensions
{
    public static class AddSwaggerExtension
    {

        public static WebApplication UseSwagerMiddelwares(this WebApplication app)
        {

            app.UseSwagger();
            app.UseSwaggerUI();

            return app;


        }





    }
}
