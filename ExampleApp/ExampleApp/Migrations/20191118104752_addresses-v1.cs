using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleApp.Migrations
{
    public partial class addressesv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "address_country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Locale = table.Column<string>(nullable: false),
                    AddressDtoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address_country", x => new { x.Id, x.Locale });
                    table.ForeignKey(
                        name: "FK_address_country_address_AddressDtoId",
                        column: x => x.AddressDtoId,
                        principalTable: "address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_country_AddressDtoId",
                table: "address_country",
                column: "AddressDtoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address_country");

            migrationBuilder.DropTable(
                name: "address");
        }
    }
}
