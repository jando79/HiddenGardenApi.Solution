using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HiddenGarden.Migrations
{
    public partial class addFieldForUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Backyards",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Backyards",
                keyColumn: "BackyardId",
                keyValue: 3,
                column: "Instructions",
                value: "Come up to the window and ask for Pierre!");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Backyards");

            migrationBuilder.UpdateData(
                table: "Backyards",
                keyColumn: "BackyardId",
                keyValue: 3,
                column: "Instructions",
                value: "Come up to the window and ask for knock!");
        }
    }
}
