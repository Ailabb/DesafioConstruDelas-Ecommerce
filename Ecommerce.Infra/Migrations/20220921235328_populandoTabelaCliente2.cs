using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Infra.Migrations
{
    public partial class populandoTabelaCliente2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "DataNascimento", "NomeCliente" },
                values: new object[] { 2, new DateTime(1990, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria Ferreira" });

            migrationBuilder.InsertData(
                table: "DadosContatoCliente",
                columns: new[] { "Id", "Celular", "ClienteId", "Email", "TelefoneResidencial" },
                values: new object[] { 2, "71-987875224", 2, "marifer@gmail.com", "71-33557845" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DadosContatoCliente",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
