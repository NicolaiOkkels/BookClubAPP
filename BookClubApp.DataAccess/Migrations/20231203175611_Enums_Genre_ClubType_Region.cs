using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookClubApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Enums_Genre_ClubType_Region : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "BookClubs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Genre", "Region", "Type" },
                values: new object[] { "Fiction", "NorthAmerica", "Online" });

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Genre", "Type" },
                values: new object[] { "NonFiction", "Local" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "BookClubs");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Region", "Type" },
                values: new object[] { "North America", "Fiction" });

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Non-Fiction");
        }
    }
}
