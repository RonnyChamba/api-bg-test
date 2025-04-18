using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPruebaIntegrity.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRestrictRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_company_company_id",
                table: "users");

            migrationBuilder.CreateIndex(
                name: "IX_customers_CompanyId",
                table: "customers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_company_CompanyId",
                table: "customers",
                column: "CompanyId",
                principalTable: "company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_company_company_id",
                table: "users",
                column: "company_id",
                principalTable: "company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_company_CompanyId",
                table: "customers");

            migrationBuilder.DropForeignKey(
                name: "FK_users_company_company_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_customers_CompanyId",
                table: "customers");

            migrationBuilder.AddForeignKey(
                name: "FK_users_company_company_id",
                table: "users",
                column: "company_id",
                principalTable: "company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
