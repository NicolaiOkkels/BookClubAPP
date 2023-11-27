using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookClubApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Added_membership_and_role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_BookClubs_BookClubId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_BookClubId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "BookClubId",
                table: "Members");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    BookClubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => new { x.MemberId, x.BookClubId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Memberships_BookClubs_BookClubId",
                        column: x => x.BookClubId,
                        principalTable: "BookClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_BookClubId",
                table: "Memberships",
                column: "BookClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_RoleId",
                table: "Memberships",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "BookClubId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Members_BookClubId",
                table: "Members",
                column: "BookClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_BookClubs_BookClubId",
                table: "Members",
                column: "BookClubId",
                principalTable: "BookClubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
