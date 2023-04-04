using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HiddenGarden.Migrations
{
    public partial class UpdateHiddenGardenContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Backyards",
                columns: new[] { "BackyardId", "Address", "Description", "Instructions", "Latitude", "Longitude", "Service" },
                values: new object[] { 2, "Bennelong Point, Sydney NSW 2000, Australia", "Free Apples", "Ask the receptionist for apples!", 0f, 0f, "Apple Trees" });

            migrationBuilder.InsertData(
                table: "Backyards",
                columns: new[] { "BackyardId", "Address", "Description", "Instructions", "Latitude", "Longitude", "Service" },
                values: new object[] { 3, "Pierre’s Bakery, Portland, OR", "Day after baked goods", "Come up to the window and ask for knock!", 0f, 0f, "Bread and Pastries" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Backyards",
                keyColumn: "BackyardId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Backyards",
                keyColumn: "BackyardId",
                keyValue: 3);
        }
    }
}
