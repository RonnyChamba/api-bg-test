using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPruebaIntegrity.Migrations
{
    /// <inheritdoc />
    public partial class AddRelatiShipInvoiceUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_invoices_user_id",
                table: "invoices",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_users_user_id",
                table: "invoices",
                column: "user_id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoices_users_user_id",
                table: "invoices");

            migrationBuilder.DropIndex(
                name: "IX_invoices_user_id",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "invoices");
        }
    }
}
