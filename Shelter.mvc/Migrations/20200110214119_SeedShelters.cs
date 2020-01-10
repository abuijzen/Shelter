using Microsoft.EntityFrameworkCore.Migrations;

namespace Shelter.mvc.Migrations
{
    public partial class SeedShelters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shelters",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Shelters",
                columns: new[] { "Id", "Address", "EmailAdress", "ImageUrl", "Name", "TelephoneNumber" },
                values: new object[] { 1, "Kievitstraat 40", "/", "canina", "Canina", "036771291" });

            migrationBuilder.InsertData(
                table: "Shelters",
                columns: new[] { "Id", "Address", "EmailAdress", "ImageUrl", "Name", "TelephoneNumber" },
                values: new object[] { 2, "Toekomststraat 4", "veeweyde.weelde@skynet.be", "image", "Veeweyde vzw", "014658626" });

            migrationBuilder.InsertData(
                table: "Shelters",
                columns: new[] { "Id", "Address", "EmailAdress", "ImageUrl", "Name", "TelephoneNumber" },
                values: new object[] { 3, "Houwaartstraat 15, 3210 Lubbeek", "info@kat-lijn.be", "https://www.dierendonatie.be/wp-content/uploads/2019/01/29570550_2080399628857532_4696137069563272630_n.jpg", "kat-lijn vzw", "0468 56 93 72" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shelters",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
