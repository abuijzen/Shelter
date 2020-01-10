using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shelter.mvc.Migrations
{
    public partial class SeedOtherShelters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Allergies", "Bio", "DateOfBirth", "IsAnimalFriendly", "IsFertile", "IsKidFriendly", "IsSpeciesFriendly", "Name", "Race", "ShelterId", "Since" },
                values: new object[,]
                {
                    { 7, "geen", "Ludo is een lievertje maar niet voor andere dieren.", new DateTime(2015, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, true, false, "Ludo", "Europeese korthaar", 2, new DateTime(2018, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Kip", "Puk is een echte ronkende franse buldog, door gezondheidsproblemen is hij bij ons beland", new DateTime(2018, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, true, true, "Puk", "Franse Bulldog", 2, new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "geen", "Moesti is een echte dierenvriend van kleine kinderen houden ze niet", new DateTime(2014, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, true, "Moesti", "Europeese korthaar", 2, new DateTime(2016, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "geen", "Marcel is een oude gek, op zijn oude dag heeft hij nog veel liefde voor tennisballen", new DateTime(2009, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, true, true, "Marcel", "Teckel", 2, new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "geen", "Olaf is een vinnig beestje, perfect voor jonge gezinnen", new DateTime(2017, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, true, true, "Olaf", "Rijnlander", 2, new DateTime(2018, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "geen", "Garret houd van kinderen en mensen, van andere dieren gaat hij lopen.", new DateTime(2015, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, true, false, "Garret", "Franse Hangoor", 2, new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "geen", "Astrix is een grote jongen die veel liefde geeft", new DateTime(2017, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, true, true, "Astrix", "Mastino Napoletano", 2, new DateTime(2018, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "kip", "Rock is een grote dikke vriend van iedereen", new DateTime(2016, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, true, true, "Rock", "Staffordshire Bull Terrier", 2, new DateTime(2017, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "geen", "Een kat met de nodige kattenstreken.", new DateTime(2003, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, false, false, "Wolf", "Bombay ", 3, new DateTime(2004, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "geen", "Een lieverd, begroet iedereen met een kopstootje.", new DateTime(2007, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, true, true, "Pom pom", "Bengaalse tijgerkat", 3, new DateTime(2010, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "wortels", "Nijntje, lief klein konijntje.", new DateTime(2018, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, false, "Nijntje", "Kleurdwerg", 2, new DateTime(2018, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "rinitis", "Een witte konijn met een hoge aaibaarheidsfactor.", new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, true, false, "Sneeuwtje", "Amerikaanse konijn", 3, new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "geen", "Mimi is bang voor veel dingen maar overwint haar angsten voor haar baasjes.", new DateTime(2002, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, true, false, "Mimi", "Pommeriaan", 3, new DateTime(2018, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "kip", "Een jong meisje met klasse, dat is Elisabeth III", new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, true, true, "Elisabeth III", "Bobtail", 3, new DateTime(2019, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "Clawed" },
                values: new object[,]
                {
                    { 16, true },
                    { 15, true },
                    { 7, true },
                    { 9, true }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Barker" },
                values: new object[,]
                {
                    { 8, true },
                    { 10, false },
                    { 13, true },
                    { 14, true },
                    { 19, true },
                    { 20, true }
                });

            migrationBuilder.InsertData(
                table: "Rabbits",
                columns: new[] { "Id", "Size" },
                values: new object[,]
                {
                    { 17, "small" },
                    { 14, null },
                    { 13, null },
                    { 12, null },
                    { 7, null },
                    { 10, null },
                    { 9, null },
                    { 8, null },
                    { 11, null },
                    { 18, "small" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Rabbits",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rabbits",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rabbits",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rabbits",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rabbits",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rabbits",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rabbits",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rabbits",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Rabbits",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Rabbits",
                keyColumn: "Id",
                keyValue: 18);
        }
    }
}
