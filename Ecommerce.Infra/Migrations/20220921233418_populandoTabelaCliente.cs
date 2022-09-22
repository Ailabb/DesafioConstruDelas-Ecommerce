using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Infra.Migrations
{
    public partial class populandoTabelaCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "DataNascimento", "NomeCliente" },
                values: new object[] { 1, new DateTime(1990, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fernanda Santos" });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "ValorUnitario" },
                values: new object[,]
                {
                    { 3, "Caderno", 12.0 },
                    { 4, "Estojo", 20.0 },
                    { 5, "Mochila", 50.0 },
                    { 6, "Bloco de Notas", 2.2999999999999998 }
                });

            migrationBuilder.InsertData(
                table: "DadosContatoCliente",
                columns: new[] { "Id", "Celular", "ClienteId", "Email", "TelefoneResidencial" },
                values: new object[] { 1, "71-987456688", 1, "fernandaS@gmail.com", "71-33558877" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DadosContatoCliente",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
