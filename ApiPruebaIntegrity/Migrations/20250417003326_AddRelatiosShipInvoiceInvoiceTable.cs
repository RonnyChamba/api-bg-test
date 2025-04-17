using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPruebaIntegrity.Migrations
{
    /// <inheritdoc />
    public partial class AddRelatiosShipInvoiceInvoiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "customer_id",
                table: "invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "invoice_details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_invoices_customer_id",
                table: "invoices",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_details_product_id",
                table: "invoice_details",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_invoice_details_products_product_id",
                table: "invoice_details",
                column: "product_id",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_customers_customer_id",
                table: "invoices",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoice_details_products_product_id",
                table: "invoice_details");

            migrationBuilder.DropForeignKey(
                name: "FK_invoices_customers_customer_id",
                table: "invoices");

            migrationBuilder.DropIndex(
                name: "IX_invoices_customer_id",
                table: "invoices");

            migrationBuilder.DropIndex(
                name: "IX_invoice_details_product_id",
                table: "invoice_details");

            migrationBuilder.DropColumn(
                name: "customer_id",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "invoice_details");
        }
    }
}
