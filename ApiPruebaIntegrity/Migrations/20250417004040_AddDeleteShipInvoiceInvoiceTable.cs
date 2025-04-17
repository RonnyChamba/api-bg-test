using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPruebaIntegrity.Migrations
{
    /// <inheritdoc />
    public partial class AddDeleteShipInvoiceInvoiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoices_invoices_InvoiceId",
                table: "invoices");

            migrationBuilder.DropIndex(
                name: "IX_invoices_InvoiceId",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "invoices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "invoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoices_InvoiceId",
                table: "invoices",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_invoices_InvoiceId",
                table: "invoices",
                column: "InvoiceId",
                principalTable: "invoices",
                principalColumn: "Id");
        }
    }
}
