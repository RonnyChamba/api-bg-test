using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPruebaIntegrity.Migrations
{
    /// <inheritdoc />
    public partial class AlterNameColumnUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_company_company_id",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "company_id",
                table: "users",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_users_company_id",
                table: "users",
                newName: "IX_users_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_company_CompanyId",
                table: "users",
                column: "CompanyId",
                principalTable: "company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_company_CompanyId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "users",
                newName: "company_id");

            migrationBuilder.RenameIndex(
                name: "IX_users_CompanyId",
                table: "users",
                newName: "IX_users_company_id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_company_company_id",
                table: "users",
                column: "company_id",
                principalTable: "company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
