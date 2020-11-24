using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Domain.Migrations
{
    public partial class Change_Table_User_And_Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Roles");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmation",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmation",
                table: "Roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Roles",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Carts",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Roles_RoleId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Roles_RoleId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RoleId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Carts_RoleId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "IsConfirmation",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsConfirmation",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Carts");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
