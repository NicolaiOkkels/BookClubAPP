using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookClubApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Added_liberies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "Email", "LibrarieAddress", "LibrarieCity", "LibrarieName", "LibrarieNumber", "LibrarieZipCode", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "kb@kb.dk", "Christians Brygge 8", "København K", "Poster vedr. sproglige minoriteter Det Kgl. Bibliotek", 700300, 1219, "33474747" },
                    { 2, "dcb@dcbib.dk", "Norderstrasse 59, 24939 Flensburg", "Padborg", "Dansk Centralbibliotek for Sydslesvig e.V.", 700400, 6330, "+4946186970" },
                    { 3, "bibliotek@kff.kk.dk", "Krystalgade 15", "København K", "Københavns Biblioteker", 710100, 1172, "33663000" },
                    { 4, "biblioteket@frederiksberg.dk", "Falkonér Plads 3", "Frederiksberg", "Biblioteket Frederiksberg", 714700, 2000, "38211800" },
                    { 5, "dcb@dcbib.dk", "Banegårdspladsen 1", "Ballerup", "Ballerup Bibliotekerne", 715100, 2750, "44773333" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
