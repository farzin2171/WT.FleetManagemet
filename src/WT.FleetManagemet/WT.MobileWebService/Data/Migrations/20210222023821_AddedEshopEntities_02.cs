using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WT.MobileWebService.Data.Migrations
{
    public partial class AddedEshopEntities_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DispatchOrders_Dispatches_DispatchId",
                table: "DispatchOrders");

            migrationBuilder.DropIndex(
                name: "IX_DispatchOrders_DispatchId",
                table: "DispatchOrders");

            migrationBuilder.DropColumn(
                name: "DispatchId",
                table: "DispatchOrders");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchOrders_DipatchId",
                table: "DispatchOrders",
                column: "DipatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_DispatchOrders_Dispatches_DipatchId",
                table: "DispatchOrders",
                column: "DipatchId",
                principalTable: "Dispatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DispatchOrders_Dispatches_DipatchId",
                table: "DispatchOrders");

            migrationBuilder.DropIndex(
                name: "IX_DispatchOrders_DipatchId",
                table: "DispatchOrders");

            migrationBuilder.AddColumn<Guid>(
                name: "DispatchId",
                table: "DispatchOrders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DispatchOrders_DispatchId",
                table: "DispatchOrders",
                column: "DispatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_DispatchOrders_Dispatches_DispatchId",
                table: "DispatchOrders",
                column: "DispatchId",
                principalTable: "Dispatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
