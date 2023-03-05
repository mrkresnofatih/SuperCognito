using DesertCamel.BaseMicroservices.SuperCognito.Entity;
using Microsoft.EntityFrameworkCore;

namespace DesertCamel.BaseMicroservices.SuperCognito.EntityFramework
{
    public class SuperCognitoDbContext : DbContext
    {
        public SuperCognitoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserPoolEntity> UserPools { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<ResourceEntity> Resources { get; set; }
        public DbSet<PermissionEntity> Permissions { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserAttributeEntity> UserAttributes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResourceEntity>()
                .HasOne(p => p.Role)
                .WithMany(p => p.Resources)
                .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<PermissionEntity>()
                .HasOne(p => p.Role)
                .WithMany(p => p.Permissions)
                .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<RoleEntity>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<UserPoolVectorEntity>()
                .HasOne(p => p.UserPool)
                .WithMany(p => p.UserPoolVectors)
                .HasForeignKey(p => p.UserPoolId);

            modelBuilder.Entity<UserEntity>()
                .HasOne(p => p.UserPool)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.UserPoolId);

            modelBuilder.Entity<UserEntity>()
                .HasIndex(p => p.PrincipalName)
                .IsUnique();

            modelBuilder.Entity<UserAttributeEntity>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserAttributes)
                .HasForeignKey(p => p.UserId);
        }
    }
}
