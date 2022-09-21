using DesafioConstrudelas_EcommerceJuntosSomosMais.Controllers;
using Ecommerce.Application.UseCases;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class ClienteTest
    {
        [Fact]
        public async Task ObterLista_Clientes_SucessoAsync() 
        {
            var clientes = new List<Cliente>()
            {
                new Cliente
                {
                    Id = 1,
                    NomeCliente = "Maria Fernandes",
                    DataNascimento = DateTime.Today,
                    Contato = new DadosContatoCliente
                    {
                        Id = 1,
                        ClienteId = 1,
                        Celular = "71-999998877",
                        TelefoneResidencial = "71-39998877",
                        Email = "mariafer@hotmail.com"

                    }
                }
            };
            Mock<IClienteRepository> _clienteRepositoryMock = new();
            _clienteRepositoryMock.Setup(s => s.ListagemDeClientes()).ReturnsAsync(clientes);

            Mock<IClienteUseCase> _clienteUseCaseMock = new();
            _clienteUseCaseMock.Setup(s => s.ListagemDeClientes()).ReturnsAsync(clientes);

            ClientesController _clientesController = new(Mock.Of<ILogger<ClientesController>>(), _clienteUseCaseMock.Object);
            var actionResult = await _clientesController.Get();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().Be(clientes);
        }

        [Fact]
        public async Task ObterLista_ClientesPorId_SucessoAsync()
        {
            var cliente = new Cliente
            {
                Id = 1,
                NomeCliente = "Maria Fernandes",
                DataNascimento = DateTime.Today,
                Contato = new DadosContatoCliente
                {
                    Id = 1,
                    ClienteId = 1,
                    Celular = "71-999998877",
                    TelefoneResidencial = "71-39998877",
                    Email = "mariafer@hotmail.com"

                }
            };

            Mock<IClienteRepository> _clienteRepositoryMock = new();
            _clienteRepositoryMock.Setup(s => s.BuscaPorId(cliente.Id)).ReturnsAsync(cliente);

            Mock<IClienteUseCase> _clienteUseCaseMock = new();
            _clienteUseCaseMock.Setup(s => s.BuscaPorId(cliente.Id)).ReturnsAsync(cliente);

            ClientesController _clientesController = new(Mock.Of<ILogger<ClientesController>>(), _clienteUseCaseMock.Object);
            var actionResult = await _clientesController.GetPorId(cliente.Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().Be(cliente);
        }
    }
}
