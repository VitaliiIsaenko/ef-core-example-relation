using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleApp.Migrations
{
    public partial class V2StatesCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address_country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Locale = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address_country", x => new { x.Id, x.Locale });
                });

            migrationBuilder.CreateTable(
                name: "address_state",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Locale = table.Column<string>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address_state", x => new { x.Id, x.Locale });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address_country");

            migrationBuilder.DropTable(
                name: "address_state");
        }
    }
}
