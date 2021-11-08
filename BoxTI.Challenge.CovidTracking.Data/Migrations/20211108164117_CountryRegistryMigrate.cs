using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoxTI.Challenge.CovidTracking.Data.Migrations
{
    public partial class CountryRegistryMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CountryCovidRegistry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActiveCases = table.Column<int>(type: "int", nullable: false),
                    NewCases = table.Column<int>(type: "int", nullable: false),
                    NewDeaths = table.Column<int>(type: "int", nullable: false),
                    TotalCases = table.Column<int>(type: "int", nullable: false),
                    TotalDeaths = table.Column<int>(type: "int", nullable: false),
                    TotalRecovered = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCovidRegistry", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryCovidRegistry");
        }
    }
}
