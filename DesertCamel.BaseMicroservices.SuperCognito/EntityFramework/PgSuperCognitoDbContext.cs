using Microsoft.EntityFrameworkCore;

namespace DesertCamel.BaseMicroservices.SuperCognito.EntityFramework
{
    public class PgSuperCognitoDbContext : SuperCognitoDbContext
    {
        public PgSuperCognitoDbContext(DbContextOptions<PgSuperCognitoDbContext> options) : base(options)
        {
        }
    }
}
