using Ecommerce.Application.Models;
using Ecommerce.Application.UseCases;
using Ecommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioConstrudelas_EcommerceJuntosSomosMais.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly ILogger<ProdutosController> _logger;
        private readonly IProdutoUseCase _produtoUseCase;
        public ProdutosController(ILogger<ProdutosController> logger,
            IProdutoUseCase produtoUseCase)
        {
            _logger = logger;
            _produtoUseCase = produtoUseCase;
        }

        [HttpGet]
        //Endpoint para Listagem de todos os produtos
        public async Task<ActionResult<List<ProdutoResponse>>> Get()
        {
            var produtos = await _produtoUseCase.ListagemDeProdutos();
            if (produtos == null)
                return NotFound();

            var listaProdutos = new List<ProdutoResponse>();
            foreach (var produto in produtos)
            {
                var response = new ProdutoResponse
                {
                    NomeProduto = produto.Nome,
                    ValorDoProduto = produto.ValorUnitario,
                };

                listaProdutos.Add(response);
            }

            return Ok(listaProdutos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoResponse>> GetPorId(int id)
        {
            var produto = await _produtoUseCase.BuscaPorId(id);

            if (produto == null)
                return NotFound("Produto não cadastrado");
            var response = new ProdutoResponse
            {
                NomeProduto = produto.Nome,
                ValorDoProduto = produto.ValorUnitario,
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(ProdutoRequest request)
        {
            if (request.ValorDoProduto <= 0)
            {
                return BadRequest("O valor do produto não deve ser inferior a R$ 0,00");
            }
            var produto = new Produto
            {
                Nome = request.NomeProduto,
                ValorUnitario = request.ValorDoProduto,
            };
            await _produtoUseCase.CadastrarProduto(produto);
            return NoContent();
        }
    }
}
