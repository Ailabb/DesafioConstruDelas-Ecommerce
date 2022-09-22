using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Infra.Migrations
{
    public partial class populandoTabelaPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "ClienteId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ItemPedido",
                columns: new[] { "Id", "PedidoId", "ProdutoId", "Quantidade" },
                values: new object[] { 1, 1, 3, 2 });

            migrationBuilder.InsertData(
                table: "ItemPedido",
                columns: new[] { "Id", "PedidoId", "ProdutoId", "Quantidade" },
                values: new object[] { 2, 1, 1, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemPedido",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemPedido",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
