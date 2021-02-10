using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WT.MobileWebService.Data.Migrations
{
    public partial class AddedLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Lon = table.Column<double>(nullable: false),
                    RecivedDate = table.Column<DateTime>(nullable: false),
                    SampledDate = table.Column<DateTime>(nullable: false),
                    IsTransfered = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
