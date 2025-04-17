using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPruebaIntegrity.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexFilterInvoiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CreateAt",
                table: "invoices",
                column: "CreateAt");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Total",
                table: "invoices",
                column: "Total");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoice_CreateAt",
                table: "invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_Total",
                table: "invoices");
        }
    }
}
