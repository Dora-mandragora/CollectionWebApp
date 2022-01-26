using Microsoft.EntityFrameworkCore.Migrations;

namespace CollectionWebApp.Migrations
{
    public partial class DeleteColumnTheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Collections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
