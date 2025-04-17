using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPruebaIntegrity.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexInvoiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Invoice_FullNameCustomer",
                table: "invoices",
                column: "FullNameCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceNumber",
                table: "invoices",
                column: "InvoiceNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoice_FullNameCustomer",
                table: "invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_InvoiceNumber",
                table: "invoices");
        }
    }
}
