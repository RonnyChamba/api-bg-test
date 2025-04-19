using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPruebaIntegrity.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldRelationInvoiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_invoice_details_products_product_id",
            //    table: "invoice_details");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_invoices_customers_customer_id",
            //    table: "invoices");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_invoices_users_user_id",
            //    table: "invoices");

            //migrationBuilder.RenameColumn(
            //    name: "user_id",
            //    table: "invoices",
            //    newName: "customerId");

            //migrationBuilder.RenameColumn(
            //    name: "customer_id",
            //    table: "invoices",
            //    newName: "UserIdId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_invoices_user_id",
            //    table: "invoices",
            //    newName: "IX_invoices_customerId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_invoices_customer_id",
            //    table: "invoices",
            //    newName: "IX_invoices_UserIdId");

            //migrationBuilder.RenameColumn(
            //    name: "product_id",
            //    table: "invoice_details",
            //    newName: "ProductIdId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_invoice_details_product_id",
            //    table: "invoice_details",
            //    newName: "IX_invoice_details_ProductIdId");

            //migrationBuilder.AddColumn<int>(
            //    name: "CustomerIdId",
            //    table: "invoices",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "UserId1",
            //    table: "invoices",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "ProductId1",
            //    table: "invoice_details",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_invoices_CustomerIdId",
            //    table: "invoices",
            //    column: "CustomerIdId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_invoices_UserId1",
            //    table: "invoices",
            //    column: "UserId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_invoice_details_ProductId1",
            //    table: "invoice_details",
            //    column: "ProductId1");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_invoice_details_products_ProductId1",
            //    table: "invoice_details",
            //    column: "ProductId1",
            //    principalTable: "products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_invoice_details_products_ProductIdId",
            //    table: "invoice_details",
            //    column: "ProductIdId",
            //    principalTable: "products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_invoices_customers_CustomerIdId",
            //    table: "invoices",
            //    column: "CustomerIdId",
            //    principalTable: "customers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_invoices_customers_customerId",
            //    table: "invoices",
            //    column: "customerId",
            //    principalTable: "customers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_invoices_users_UserId1",
            //    table: "invoices",
            //    column: "UserId1",
            //    principalTable: "users",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_invoices_users_UserIdId",
            //    table: "invoices",
            //    column: "UserIdId",
            //    principalTable: "users",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_invoice_details_products_ProductId1",
            //    table: "invoice_details");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_invoice_details_products_ProductIdId",
            //    table: "invoice_details");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_invoices_customers_CustomerIdId",
            //    table: "invoices");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_invoices_customers_customerId",
            //    table: "invoices");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_invoices_users_UserId1",
            //    table: "invoices");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_invoices_users_UserIdId",
            //    table: "invoices");

            //migrationBuilder.DropIndex(
            //    name: "IX_invoices_CustomerIdId",
            //    table: "invoices");

            //migrationBuilder.DropIndex(
            //    name: "IX_invoices_UserId1",
            //    table: "invoices");

            //migrationBuilder.DropIndex(
            //    name: "IX_invoice_details_ProductId1",
            //    table: "invoice_details");

            //migrationBuilder.DropColumn(
            //    name: "CustomerIdId",
            //    table: "invoices");

            //migrationBuilder.DropColumn(
            //    name: "UserId1",
            //    table: "invoices");

            //migrationBuilder.DropColumn(
            //    name: "ProductId1",
            //    table: "invoice_details");

            //migrationBuilder.RenameColumn(
            //    name: "customerId",
            //    table: "invoices",
            //    newName: "user_id");

            //migrationBuilder.RenameColumn(
            //    name: "UserIdId",
            //    table: "invoices",
            //    newName: "customer_id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_invoices_UserIdId",
            //    table: "invoices",
            //    newName: "IX_invoices_customer_id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_invoices_customerId",
            //    table: "invoices",
            //    newName: "IX_invoices_user_id");

            //migrationBuilder.RenameColumn(
            //    name: "ProductIdId",
            //    table: "invoice_details",
            //    newName: "product_id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_invoice_details_ProductIdId",
            //    table: "invoice_details",
            //    newName: "IX_invoice_details_product_id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_invoice_details_products_product_id",
            //    table: "invoice_details",
            //    column: "product_id",
            //    principalTable: "products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_invoices_customers_customer_id",
            //    table: "invoices",
            //    column: "customer_id",
            //    principalTable: "customers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_invoices_users_user_id",
            //    table: "invoices",
            //    column: "user_id",
            //    principalTable: "users",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
