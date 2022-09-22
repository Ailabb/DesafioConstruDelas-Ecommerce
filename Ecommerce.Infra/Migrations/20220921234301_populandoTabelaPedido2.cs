using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Infra.Migrations
{
    public partial class populandoTabelaPedido2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ItemPedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProdutoId",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ItemPedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProdutoId",
                value: 1);
        }
    }
}
