using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Domain.Migrations
{
    public partial class Remove_Table_Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Roles_RoleId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Roles_RoleId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RoleId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Carts_RoleId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Carts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserProfiles",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "UserProfiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sex",
                table: "UserProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RoleId",
                table: "Orders",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_RoleId",
                table: "Carts",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Roles_RoleId",
                table: "Carts",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Roles_RoleId",
                table: "Orders",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
