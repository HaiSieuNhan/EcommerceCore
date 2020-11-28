using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Domain.Migrations
{
    public partial class Add_Column_Description_and_GroupConfig_In_Table_Config : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Configs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupConfig",
                table: "Configs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "GroupConfig",
                table: "Configs");
        }
    }
}
