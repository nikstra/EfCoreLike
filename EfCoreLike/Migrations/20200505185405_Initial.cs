using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreLike.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    JoinDate = table.Column<DateTime>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Address1", "Address2", "BirthDate", "City", "Country", "FirstName", "JoinDate", "LastName", "PostCode" },
                values: new object[,]
                {
                    { 1, "Gatan 5", null, new DateTime(1975, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uppsala", "Sverige", "Lisa", new DateTime(2014, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johansson", "75455" },
                    { 2, "Vägen 55", null, new DateTime(1992, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uppsala", "Sverige", "Oscar", new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bengtsson", "75450" },
                    { 3, "Långgatan 9", null, new DateTime(2002, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stockholm", "Sverige", "Fia", new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sten", "11011" },
                    { 4, "Stora vägen 42", null, new DateTime(1984, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Umeå", "Sverige", "Kalle", new DateTime(2010, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Berg", "95433" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
