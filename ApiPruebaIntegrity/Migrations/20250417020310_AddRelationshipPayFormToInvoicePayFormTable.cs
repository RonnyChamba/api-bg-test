using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPruebaIntegrity.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipPayFormToInvoicePayFormTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pay_form_id",
                table: "invoice_pay_form",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_invoice_pay_form_pay_form_id",
                table: "invoice_pay_form",
                column: "pay_form_id");

            migrationBuilder.AddForeignKey(
                name: "FK_invoice_pay_form_pay_forms_pay_form_id",
                table: "invoice_pay_form",
                column: "pay_form_id",
                principalTable: "pay_forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoice_pay_form_pay_forms_pay_form_id",
                table: "invoice_pay_form");

            migrationBuilder.DropIndex(
                name: "IX_invoice_pay_form_pay_form_id",
                table: "invoice_pay_form");

            migrationBuilder.DropColumn(
                name: "pay_form_id",
                table: "invoice_pay_form");
        }
    }
}
