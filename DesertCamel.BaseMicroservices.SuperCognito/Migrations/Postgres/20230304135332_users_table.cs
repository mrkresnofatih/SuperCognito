using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesertCamel.BaseMicroservices.SuperCognito.Migrations.Postgres
{
    public partial class users_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEntity_UserPools_UserPoolId",
                table: "UserEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity");

            migrationBuilder.RenameTable(
                name: "UserEntity",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_UserEntity_UserPoolId",
                table: "Users",
                newName: "IX_Users_UserPoolId");

            migrationBuilder.RenameIndex(
                name: "IX_UserEntity_PrincipalName",
                table: "Users",
                newName: "IX_Users_PrincipalName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAttributes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAttributes_UserId",
                table: "UserAttributes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserPools_UserPoolId",
                table: "Users",
                column: "UserPoolId",
                principalTable: "UserPools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserPools_UserPoolId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserAttributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserPoolId",
                table: "UserEntity",
                newName: "IX_UserEntity_UserPoolId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PrincipalName",
                table: "UserEntity",
                newName: "IX_UserEntity_PrincipalName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEntity_UserPools_UserPoolId",
                table: "UserEntity",
                column: "UserPoolId",
                principalTable: "UserPools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
