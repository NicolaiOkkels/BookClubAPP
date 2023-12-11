using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookClubApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddLibraries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibrarieNumber = table.Column<int>(type: "int", nullable: false),
                    LibrarieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibrarieAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibrarieZipCode = table.Column<int>(type: "int", nullable: true),
                    LibrarieCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "Email", "LibrarieAddress", "LibrarieCity", "LibrarieName", "LibrarieNumber", "LibrarieZipCode", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "kb@kb.dk", "Christians Brygge 8", "København K", "Poster vedr. sproglige minoriteter Det Kgl. Bibliotek", 700300, 1219, "33474747" },
                    { 2, "dcb@dcbib.dk", "Norderstrasse 59, 24939 Flensburg", "Padborg", "Dansk Centralbibliotek for Sydslesvig e.V.", 700400, 6330, "+4946186970" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libraries");
        }
    }
}
