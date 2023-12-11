using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookClubApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BookClub_Regions_removed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "BookClubs");

            migrationBuilder.AddColumn<int>(
                name: "LibrariesId",
                table: "BookClubs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "LibrariesId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "LibrariesId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_BookClubs_LibrariesId",
                table: "BookClubs",
                column: "LibrariesId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookClubs_Libraries_LibrariesId",
                table: "BookClubs",
                column: "LibrariesId",
                principalTable: "Libraries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookClubs_Libraries_LibrariesId",
                table: "BookClubs");

            migrationBuilder.DropIndex(
                name: "IX_BookClubs_LibrariesId",
                table: "BookClubs");

            migrationBuilder.DropColumn(
                name: "LibrariesId",
                table: "BookClubs");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "BookClubs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Region",
                value: "NorthAmerica");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Region",
                value: "Europe");
        }
    }
}
