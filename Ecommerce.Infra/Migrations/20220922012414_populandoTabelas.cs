using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Infra.Migrations
{
    public partial class populandoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "DataNascimento", "NomeCliente" },
                values: new object[,]
                {
                    { 3, new DateTime(1988, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bianca Torres" },
                    { 4, new DateTime(1994, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amanda Gusmao" },
                    { 5, new DateTime(1996, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fernando Sampaio" },
                    { 6, new DateTime(1989, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bruno Gomes" },
                    { 7, new DateTime(1987, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paula Motta" }
                });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "ClienteId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "DadosContatoCliente",
                columns: new[] { "Id", "Celular", "ClienteId", "Email", "TelefoneResidencial" },
                values: new object[,]
                {
                    { 3, "71-976248688", 3, "biancatorres@gmail.com", "71-32365877" },
                    { 4, "71-924598224", 4, "mandagus@gmail.com", "71-37894645" },
                    { 5, "71-987878459", 5, "fernandospr@gmail.com", "71-36877845" },
                    { 6, "71-987458688", 6, "brunno.gomes@gmail.com", "71-33655877" },
                    { 7, "71-975648224", 7, "paula_motta@gmail.com", "71-33584645" }
                });

            migrationBuilder.InsertData(
                table: "ItemPedido",
                columns: new[] { "Id", "PedidoId", "ProdutoId", "Quantidade" },
                values: new object[] { 5, 3, 2, 5 });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "ClienteId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 4, 6 }
                });

            migrationBuilder.InsertData(
                table: "ItemPedido",
                columns: new[] { "Id", "PedidoId", "ProdutoId", "Quantidade" },
                values: new object[,]
                {
                    { 3, 2, 4, 2 },
                    { 4, 2, 5, 3 },
                    { 6, 4, 4, 1 },
                    { 7, 4, 1, 2 },
                    { 8, 4, 5, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DadosContatoCliente",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DadosContatoCliente",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DadosContatoCliente",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DadosContatoCliente",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DadosContatoCliente",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ItemPedido",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemPedido",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ItemPedido",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ItemPedido",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ItemPedido",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ItemPedido",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
