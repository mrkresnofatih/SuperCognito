namespace DesertCamel.BaseMicroservices.SuperCognito.Extensions
{
    public static class CorsSetupExtension
    {
        public static void UseSuperCognitoCorsPolicy(this IApplicationBuilder app)
        {
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:3000");
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                builder.AllowCredentials();
            });
        }
    }
}
