using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HiddenGarden.Migrations
{
    public partial class AddUpdateFromPullRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Backyards",
                keyColumn: "BackyardId",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Backyards",
                columns: new[] { "BackyardId", "Address", "Description", "Instructions", "Latitude", "Longitude", "Service", "UserId" },
                values: new object[] { 3, "Pierre’s Bakery, Portland, OR", "Day after baked goods", "Come up to the window and ask for Pierre!", 0f, 0f, "Bread and Pastries", null });
        }
    }
}
