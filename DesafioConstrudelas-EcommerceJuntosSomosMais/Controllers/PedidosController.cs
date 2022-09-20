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
    [Route("api/pedido")]
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly IPedidoUseCase _pedidoUseCase;
        private readonly IClienteUseCase _clienteUse;
        private readonly IProdutoUseCase _produtoUseCase;

        public PedidosController(ILogger<PedidosController> logger,
            IPedidoUseCase pedidoUseCase, IClienteUseCase clienteUse,
            IProdutoUseCase produtoUseCase)
        {
            _logger = logger;
            _pedidoUseCase = pedidoUseCase;
            _clienteUse = clienteUse;
            _produtoUseCase = produtoUseCase;
        }
        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> Get()
        {
            var response = await _pedidoUseCase.ListagemDePedidos();
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Pedido>>> Get(int id)
        {
            var response = await _pedidoUseCase.BuscaPorId(id);
            if (response == null)
                return NotFound("Pedido não encontrado");

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PedidoRequest request)
        {
            var cliente = await _clienteUse.BuscaPorId(request.IdCliente);
            if (cliente == null)
            {
                return BadRequest("Cliente não Cadastrado");
            }
            var itensPedido = new List<ItemPedido>();

            foreach (var item in request.Itens)
            {
                var produto = await _produtoUseCase.BuscaPorId(item.IdProduto);
                if (produto == null)
                {
                    return BadRequest("Produto não cadastrado.");
                }
                var itemPedido = new ItemPedido
                {
                    Produto = produto,
                    Quantidade = item.Quantidade,
                };
                itensPedido.Add(itemPedido);
            }
            var pedido = new Pedido
            {
                Cliente = cliente,
                Itens = itensPedido,

            };
            await _pedidoUseCase.CadastrarPedido(pedido);
            return NoContent();
        }
    }

}
