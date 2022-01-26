using Microsoft.EntityFrameworkCore.Migrations;

namespace CollectionWebApp.Migrations
{
    public partial class AddHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemHistory_Users_Id",
                table: "ItemHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemHistory_ItemHistoryId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemHistory",
                table: "ItemHistory");

            migrationBuilder.RenameTable(
                name: "ItemHistory",
                newName: "ItemHistories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemHistories",
                table: "ItemHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemHistories_Users_Id",
                table: "ItemHistories",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemHistories_ItemHistoryId",
                table: "Items",
                column: "ItemHistoryId",
                principalTable: "ItemHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemHistories_Users_Id",
                table: "ItemHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemHistories_ItemHistoryId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemHistories",
                table: "ItemHistories");

            migrationBuilder.RenameTable(
                name: "ItemHistories",
                newName: "ItemHistory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemHistory",
                table: "ItemHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemHistory_Users_Id",
                table: "ItemHistory",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemHistory_ItemHistoryId",
                table: "Items",
                column: "ItemHistoryId",
                principalTable: "ItemHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
