using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VennyHotel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHotelNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hotels",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "HotelNumbers",
                columns: table => new
                {
                    Hotel_Number = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelNumbers", x => x.Hotel_Number);
                    table.ForeignKey(
                        name: "FK_HotelNumbers_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HotelNumbers",
                columns: new[] { "Hotel_Number", "HotelId", "SpecialDetails" },
                values: new object[,]
                {
                    { 101, 1, null },
                    { 102, 1, null },
                    { 103, 1, null },
                    { 104, 1, null },
                    { 201, 2, null },
                    { 202, 2, null },
                    { 203, 2, null },
                    { 301, 3, null },
                    { 302, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelNumbers_HotelId",
                table: "HotelNumbers",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelNumbers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
