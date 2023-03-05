using DesertCamel.BaseMicroservices.SuperCognito.EntityFramework;
using DesertCamel.BaseMicroservices.SuperCognito.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DesertCamel.BaseMicroservices.SuperCognito.Extensions
{
    public static class DatabaseStartupExtension
    {
        public static void AddSuperCognitoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var selectedDatabase = configuration.GetSection(AppConstants.ConfigKeys.SELECTED_DATABASE).Value;
            switch (selectedDatabase)
            {
                case AppConstants.DatabaseTypes.POSTGRES:
                    var pgConnectionString = configuration.GetSection(AppConstants.ConfigKeys.POSTGRES_DB_CONN_STRING).Value;
                    services.AddDbContext<SuperCognitoDbContext, PgSuperCognitoDbContext>(options =>
                    {
                        options.UseNpgsql(pgConnectionString);
                    });
                    break;
                default:
                    throw new Exception("Unknown Selected Database");
            }
        }

        public static void RunSuperCognitoDbMigration(this IApplicationBuilder app, IConfiguration configuration)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var selectedDatabase = configuration.GetSection(AppConstants.ConfigKeys.SELECTED_DATABASE).Value;
                switch (selectedDatabase)
                {
                    case AppConstants.DatabaseTypes.POSTGRES:
                        var pgDb = scope.ServiceProvider.GetRequiredService<PgSuperCognitoDbContext>().Database;
                        if (pgDb.GetPendingMigrations().Any())
                        {
                            pgDb.Migrate();
                        }
                        break;
                    default:
                        throw new Exception("Unknown Selected Database");
                }
            }
        }
    }
}
