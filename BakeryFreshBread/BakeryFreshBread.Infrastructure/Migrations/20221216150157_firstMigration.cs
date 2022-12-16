using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BakeryFreshBread.Infrastructure.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    OfficeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeName = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCost = table.Column<float>(nullable: false),
                    OfficeId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Breads",
                columns: table => new
                {
                    BreadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreadName = table.Column<string>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    OfficeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breads", x => x.BreadId);
                    table.ForeignKey(
                        name: "FK_Breads_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BreadOrders",
                columns: table => new
                {
                    BreadOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreadId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreadOrders", x => x.BreadOrderId);
                    table.ForeignKey(
                        name: "FK_BreadOrders_Breads_BreadId",
                        column: x => x.BreadId,
                        principalTable: "Breads",
                        principalColumn: "BreadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreadOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreadOrders_BreadId",
                table: "BreadOrders",
                column: "BreadId");

            migrationBuilder.CreateIndex(
                name: "IX_BreadOrders_OrderId",
                table: "BreadOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Breads_OfficeId",
                table: "Breads",
                column: "OfficeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreadOrders");

            migrationBuilder.DropTable(
                name: "Breads");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
