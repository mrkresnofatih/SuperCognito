// <auto-generated />
using System;
using DesertCamel.BaseMicroservices.SuperCognito.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DesertCamel.BaseMicroservices.SuperCognito.Migrations.Postgres
{
    [DbContext(typeof(PgSuperCognitoDbContext))]
    partial class PgSuperCognitoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DesertCamel.BaseMicroservices.SuperCognito.Entity.PermissionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("DesertCamel.BaseMicroservices.SuperCognito.Entity.ResourceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("DesertCamel.BaseMicroservices.SuperCognito.Entity.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DesertCamel.BaseMicroservices.SuperCognito.Entity.UserAttributeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserAttributes");
                });

            modelBuilder.Entity("DesertCamel.BaseMicroservices.SuperCognito.Entity.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("PrincipalName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("UserPoolId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PrincipalName")
                        .IsUnique();

                    b.HasIndex("UserPoolId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DesertCamel.BaseMicroservices.SuperCognito.Entity.UserPoolEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ClientSecret")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("ExchangeTokenUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IssuerUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("JwksUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LoginPageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PrincipalNameKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("TokenLifeTime")
                        .HasColumnType("bigint");

                    b.Property<bool>("UseCache")
                        .HasColumnType("boolean");

                    b.Property<string>("UserInfoUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserPools");
                });

            modelBuilder.Entity("DesertCamel.BaseMicroservices.SuperCognito.Entity.UserPoolVectorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DestinationKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SourceKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserPoolId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserPoolId");

                    b.ToTable("UserPoolVectorEntity");
                });

            modelBuilder.Entity("DesertCamel.BaseMicroservices.SuperCognito.Entity.PermissionEntity", b =>
                {
                    b.HasOne("DesertCamel.BaseMicroservices.SuperCognito.Entity.RoleEntity", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DesertCamel.BaseMicroservices.SuperCognito.Entity.ResourceEntity", b =>
                {
                    b.HasOne("DesertCamel.BaseMicroservices.SuperCognito.Entity.RoleEntity", "Role")
                        .WithMany("Resources")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DesertCamel.BaseMicroservices.SuperCognito.Entity.UserAttributeEntity", b =>
                {
                    b.HasOne("DesertCamel.BaseMicroservices.SuperCognito.Entity.UserEntity", "User")
                        .WithMany("UserAttributes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DesertCamel.BaseMicroservices.SuperCognito.Entity.UserEntity", b =>
                {
                    b.HasOne("DesertCamel.BaseMicroservices.SuperCognito.Entity.UserPoolEntity", "UserPool")
                        .WithMany("Users")
                        .HasForeignKey("UserPoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserPool");
                });

            modelBuilder.Entity("DesertCamel.BaseMicroservices.SuperCognito.Entity.UserPoolVectorEntity", b =>
                {
                    b.HasOne("DesertCamel.BaseMicroservices.SuperCognito.Entity.UserPoolEntity", "UserPool")
                        .WithMany("UserPoolVectors")
                        .HasForeignKey("UserPoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserPool");
                });

            modelBuilder.Entity("DesertCamel.BaseMicroservices.SuperCognito.Entity.RoleEntity", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("Resources");
                });

            modelBuilder.Entity("DesertCamel.BaseMicroservices.SuperCognito.Entity.UserEntity", b =>
                {
                    b.Navigation("UserAttributes");
                });

            modelBuilder.Entity("DesertCamel.BaseMicroservices.SuperCognito.Entity.UserPoolEntity", b =>
                {
                    b.Navigation("UserPoolVectors");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
