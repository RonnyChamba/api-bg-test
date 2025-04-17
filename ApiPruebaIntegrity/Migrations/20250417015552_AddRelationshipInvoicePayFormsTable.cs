using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPruebaIntegrity.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipInvoicePayFormsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoice_pay_form_invoices_InvoiceId",
                table: "invoice_pay_form");

            migrationBuilder.DropIndex(
                name: "IX_invoice_pay_form_InvoiceId",
                table: "invoice_pay_form");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "invoice_pay_form");

            migrationBuilder.AddColumn<int>(
                name: "invoice_id",
                table: "invoice_pay_form",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_invoice_pay_form_invoice_id",
                table: "invoice_pay_form",
                column: "invoice_id");

            migrationBuilder.AddForeignKey(
                name: "FK_invoice_pay_form_invoices_invoice_id",
                table: "invoice_pay_form",
                column: "invoice_id",
                principalTable: "invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoice_pay_form_invoices_invoice_id",
                table: "invoice_pay_form");

            migrationBuilder.DropIndex(
                name: "IX_invoice_pay_form_invoice_id",
                table: "invoice_pay_form");

            migrationBuilder.DropColumn(
                name: "invoice_id",
                table: "invoice_pay_form");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "invoice_pay_form",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoice_pay_form_InvoiceId",
                table: "invoice_pay_form",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_invoice_pay_form_invoices_InvoiceId",
                table: "invoice_pay_form",
                column: "InvoiceId",
                principalTable: "invoices",
                principalColumn: "Id");
        }
    }
}
