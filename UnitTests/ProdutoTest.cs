using DesafioConstrudelas_EcommerceJuntosSomosMais.Controllers;
using Ecommerce.Application.Models;
using Ecommerce.Application.UseCases;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class ProdutoTest
    {
        [Fact]
        public async Task ObterListaProdutos_SucessoAsync()
        {
            var produtos = new List<Produto>()
            {
                new Produto
                {
                    Id =1,
                    Nome = "Caneta",
                    ValorUnitario = 1.50,
                }
            };

            var produtosResponse = new List<ProdutoResponse>
            {
                new ProdutoResponse
                {
                    NomeProduto = "Caneta",
                    ValorDoProduto = 1.50,
                }
            };

            Mock<IProdutoUseCase> _produtoUseCaseMock = new();
            _produtoUseCaseMock.Setup(s => s.ListagemDeProdutos()).ReturnsAsync(produtos);

            Mock<IProdutoRepository> _produtoRepositoryMock = new();
            _produtoRepositoryMock.Setup(s => s.ListagemDeProdutos()).ReturnsAsync(produtos);

            ProdutosController _produtosController = new(Mock.Of<ILogger<ProdutosController>>(), _produtoUseCaseMock.Object);
            var actionResult = await _produtosController.Get();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(produtosResponse);
        }

    }

}

