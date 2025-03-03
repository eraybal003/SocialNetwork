using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetworkFrontSide.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "RoleModelUserModel",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModelUserModel", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleModelUserModel_Role_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleModelUserModel_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleModelUserModel_UsersId",
                table: "RoleModelUserModel",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleModelUserModel");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
