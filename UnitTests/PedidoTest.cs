using DesafioConstrudelas_EcommerceJuntosSomosMais.Controllers;
using Ecommerce.Application.Models;
using Ecommerce.Application.UseCases;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class PedidoTest
    {
        [Fact]
        public async Task ObterListaPedidos_SucessoAsync()
        {
            var pedidos = new List<Pedido>()
            {
                new Pedido
                {
                    Id = 1,
                    ClienteId = 1,
                    Cliente = new Cliente
                    {
                        Id = 1,
                        NomeCliente = "Fernanda Montes",
                        DataNascimento = DateTime.Today,
                        Contato = new DadosContatoCliente
                        {
                            Id = 1,
                            ClienteId = 1,
                            Celular = "71-999998877",
                            TelefoneResidencial = "71-39998877",
                            Email = "mariafer@hotmail.com"

                        }
                    },                    
                    Itens = new List<ItemPedido>
                    {
                        new ItemPedido
                        {
                            Id = 1,
                            PedidoId = 1,
                            ProdutoId = 1,
                            Produto = new Produto
                            {
                                Id =1,
                                Nome = "Caneta",
                                ValorUnitario = 1.50,
                            },
                            Quantidade = 2
                        }
                    }
                }
    };

            var pedidosResponse = new List<PedidoResponse>
            {
                new PedidoResponse
                {
                    Id = 1,
                    NomeCliente = "Fernanda Montes",
                    Itens = new List<ItemPedidoResponse>()
                    {
                       new ItemPedidoResponse
                       {
                           IdProduto = 1,
                           NomeProduto = "Caneta",
                           Quantidade = 2,
                           ValorUnitario = 1.50,
                           ValorTotal = 3
                       }
                    }
                }
            };

            Mock<IPedidoUseCase> _pedidoUseCaseMock = new();
            _pedidoUseCaseMock.Setup(s => s.ListagemDePedidos()).ReturnsAsync(pedidos);

            Mock<IPedidoRepository> _pedidoRepositoryMock = new();
            _pedidoRepositoryMock.Setup(s => s.ListagemDePedidos()).ReturnsAsync(pedidos);

            Mock<IClienteUseCase> _clienteRepositoryMock = new();
            Mock<IProdutoUseCase> _produtoRepositoryMock = new();

            PedidosController _pedidosController = new(Mock.Of<ILogger<PedidosController>>(), _pedidoUseCaseMock.Object, _clienteRepositoryMock.Object, _produtoRepositoryMock.Object);
            var actionResult = await _pedidosController.Get();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(pedidosResponse);
        }
    }
}
