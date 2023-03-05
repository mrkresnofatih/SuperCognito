using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesertCamel.BaseMicroservices.SuperCognito.Migrations.Postgres
{
    public partial class create_userpool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ClientId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ClientSecret = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LoginPageUrl = table.Column<string>(type: "text", nullable: false),
                    ExchangeTokenUrl = table.Column<string>(type: "text", nullable: false),
                    UserInfoUrl = table.Column<string>(type: "text", nullable: false),
                    IssuerUrl = table.Column<string>(type: "text", nullable: false),
                    JwksUrl = table.Column<string>(type: "text", nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false),
                    UseCache = table.Column<bool>(type: "boolean", nullable: false),
                    TokenLifeTime = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPools", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPools");
        }
    }
}
