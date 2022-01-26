using Microsoft.EntityFrameworkCore.Migrations;

namespace CollectionWebApp.Migrations
{
    public partial class AddItemHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemHistoryId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemHistory_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemHistoryId",
                table: "Items",
                column: "ItemHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemHistory_ItemHistoryId",
                table: "Items",
                column: "ItemHistoryId",
                principalTable: "ItemHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemHistory_ItemHistoryId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "ItemHistory");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemHistoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemHistoryId",
                table: "Items");
        }
    }
}
