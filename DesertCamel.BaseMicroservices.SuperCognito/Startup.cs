using DesertCamel.BaseMicroservices.SuperCognito.Extensions;
using DesertCamel.BaseMicroservices.SuperCognito.Models;
using DesertCamel.BaseMicroservices.SuperCognito.Services.AuthService;
using DesertCamel.BaseMicroservices.SuperCognito.Services.CognitoService;
using DesertCamel.BaseMicroservices.SuperCognito.Services.ResourceService;
using DesertCamel.BaseMicroservices.SuperCognito.Services.RoleService;
using DesertCamel.BaseMicroservices.SuperCognito.Services.UserPoolService;
using DesertCamel.BaseMicroservices.SuperCognito.Services.UserService;

namespace DesertCamel.BaseMicroservices.SuperCognito
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSuperCognitoDbContext(Configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserPoolService, UserPoolService>();
            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<ICognitoService, CognitoService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddOptions();
            services.Configure<SuperCognitoApi>(Configuration.GetSection(SuperCognitoApi.SuperCognitoSection));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.RunSuperCognitoDbMigration(Configuration);

            app.UseRouting();
            app.UseSuperCognitoCorsPolicy();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
