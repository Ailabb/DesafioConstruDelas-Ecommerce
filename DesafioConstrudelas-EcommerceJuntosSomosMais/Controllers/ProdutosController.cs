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
        //Endpoint para Listagem de todos os clientes
        public async Task<ActionResult<List<Produto>>> Get()
        {
            var response = await _produtoUseCase.ListagemDeProdutos();
            if (response == null)
                return NotFound();

            return Ok(response);
        }
        [HttpGet("{id}")]
        //Endpoint api/clientes/id
        //Endpoint para Buscar Cliente por Id
        public async Task<ActionResult<Produto>> GetPorId(int id)
        {
            var response = await _produtoUseCase.BuscaPorId(id);

            if (response == null)
                return NotFound("Produto não cadastrado");

            return Ok(response);
        }

        [HttpPost("Cadastrar_Produto")]
        public async Task<ActionResult> Insert(Produto produto)
        {
            await _produtoUseCase.CadastrarProduto(produto);
            return NoContent();
        }
    }
}
