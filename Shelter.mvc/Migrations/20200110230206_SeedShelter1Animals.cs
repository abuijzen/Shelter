using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shelter.mvc.Migrations
{
    public partial class SeedShelter1Animals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Clawed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Barker = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rabbits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rabbits", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Allergies", "Bio", "DateOfBirth", "IsAnimalFriendly", "IsFertile", "IsKidFriendly", "IsSpeciesFriendly", "Name", "Race", "ShelterId", "Since" },
                values: new object[,]
                {
                    { 1, "catnip", "Felix is een iets schuwere kat die een baasje nodig heeft met veel geduld.", new DateTime(2005, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, true, true, "Felix", "Britse Korthaar", 1, new DateTime(2007, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "dogs", "Picasso is een kat die samen met Binky geplaatst dient te worden.", new DateTime(2005, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, true, true, "Picasso", "Ragdoll", 1, new DateTime(2007, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "none", "Ior is een kindvriendelijk konijn die graag bij andere konijntjes gezet wordt indien mogelijk.", new DateTime(2017, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, true, true, "Ior", "Hollander", 1, new DateTime(2018, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "geen", "Minoes is een sociale en lieve kitten die net van een nestje komt.", new DateTime(2010, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, "Minoes", "Europese Korthaar", 1, new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "geen", "Binky is een kat die samen met Picasso geplaatst dient te worden.", new DateTime(2016, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, "Binky", "Europese Korthaar", 1, new DateTime(2018, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Chocolade", "Mopsie is een gezonde mopshond gered uit de broodfok", new DateTime(2017, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, true, true, "Mopsie", "Mopshond", 1, new DateTime(2018, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "Clawed" },
                values: new object[,]
                {
                    { 1, true },
                    { 2, true },
                    { 4, true },
                    { 5, true }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Barker" },
                values: new object[] { 6, false });

            migrationBuilder.InsertData(
                table: "Rabbits",
                columns: new[] { "Id", "Size" },
                values: new object[] { 3, "groot" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Rabbits");

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
