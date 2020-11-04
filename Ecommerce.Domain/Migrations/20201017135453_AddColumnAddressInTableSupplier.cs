using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Domain.Migrations
{
    public partial class AddColumnAddressInTableSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryDetails_TransactionHistory_TransactionHistoryId",
                table: "HistoryDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_Promotions_PromotionId",
                table: "TransactionHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_Users_UserId",
                table: "TransactionHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionHistory",
                table: "TransactionHistory");

            migrationBuilder.RenameTable(
                name: "TransactionHistory",
                newName: "TransactionHistories");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionHistory_UserId",
                table: "TransactionHistories",
                newName: "IX_TransactionHistories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionHistory_PromotionId",
                table: "TransactionHistories",
                newName: "IX_TransactionHistories_PromotionId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Suppliers",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionHistories",
                table: "TransactionHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryDetails_TransactionHistories_TransactionHistoryId",
                table: "HistoryDetails",
                column: "TransactionHistoryId",
                principalTable: "TransactionHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistories_Promotions_PromotionId",
                table: "TransactionHistories",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistories_Users_UserId",
                table: "TransactionHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryDetails_TransactionHistories_TransactionHistoryId",
                table: "HistoryDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistories_Promotions_PromotionId",
                table: "TransactionHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistories_Users_UserId",
                table: "TransactionHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionHistories",
                table: "TransactionHistories");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Suppliers");

            migrationBuilder.RenameTable(
                name: "TransactionHistories",
                newName: "TransactionHistory");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionHistories_UserId",
                table: "TransactionHistory",
                newName: "IX_TransactionHistory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionHistories_PromotionId",
                table: "TransactionHistory",
                newName: "IX_TransactionHistory_PromotionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionHistory",
                table: "TransactionHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryDetails_TransactionHistory_TransactionHistoryId",
                table: "HistoryDetails",
                column: "TransactionHistoryId",
                principalTable: "TransactionHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_Promotions_PromotionId",
                table: "TransactionHistory",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_Users_UserId",
                table: "TransactionHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
