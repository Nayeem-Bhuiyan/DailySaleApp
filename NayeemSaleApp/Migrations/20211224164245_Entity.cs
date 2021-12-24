using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NayeemSaleApp.Migrations
{
    public partial class Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    contactNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    productCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    grossAmount = table.Column<float>(type: "real", nullable: true),
                    discountAmount = table.Column<float>(type: "real", nullable: true),
                    vatAmount = table.Column<float>(type: "real", nullable: true),
                    receiveTotal = table.Column<float>(type: "real", nullable: true),
                    payType = table.Column<int>(type: "int", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentRecords_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    rate = table.Column<float>(type: "real", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    billDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    boucherNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleRecord_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleRecord_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecords_CustomerId",
                table: "PaymentRecords",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleRecord_CustomerId",
                table: "SaleRecord",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleRecord_ProductId",
                table: "SaleRecord",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentRecords");

            migrationBuilder.DropTable(
                name: "SaleRecord");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
