using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Infra.Migrations
{
    public partial class populandoTabelaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "ValorUnitario" },
                values: new object[] { 1, "Caneta", 1.5 });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "ValorUnitario" },
                values: new object[] { 2, "Borracha", 2.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
