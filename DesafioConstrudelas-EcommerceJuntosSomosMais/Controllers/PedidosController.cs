using Ecommerce.Application.Models;
using Ecommerce.Application.UseCases;
using Ecommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<List<PedidoResponse>>> Get()
        {
            var pedidos = await _pedidoUseCase.ListagemDePedidos();
            if (pedidos == null)
                return NotFound();

            var listaPedidos = new List<PedidoResponse>();
            foreach (var pedido in pedidos)
            {
                var response = new PedidoResponse
                {
                    Id = pedido.Id,
                    NomeCliente = pedido.Cliente.NomeCliente,
                    Itens = pedido.Items.Select(itemPedido => new ItemPedidoResponse
                    {
                        IdProduto = itemPedido.Produto.Id,
                        NomeProduto = itemPedido.Produto.Nome,
                        Quantidade = itemPedido.Quantidade,
                        ValorUnitario = itemPedido.Produto.ValorUnitario,
                        ValorTotal = itemPedido.Produto.ValorUnitario * itemPedido.Quantidade
                    }).ToList(),
                };

                listaPedidos.Add(response);
            }

            return Ok(listaPedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PedidoResponse>>> Get(int id)
        {
            var pedido = await _pedidoUseCase.BuscaPorId(id);
            if (pedido == null)
                return NotFound("Pedido não encontrado");

            var response = new PedidoResponse
            {
                Id = pedido.Id,
                NomeCliente = pedido.Cliente.NomeCliente,
                Itens = pedido.Items.Select(itemPedido => new ItemPedidoResponse
                {
                    IdProduto = itemPedido.Produto.Id,
                    NomeProduto = itemPedido.Produto.Nome,
                    Quantidade = itemPedido.Quantidade,
                    ValorUnitario = itemPedido.Produto.ValorUnitario,
                    ValorTotal = itemPedido.Produto.ValorUnitario * itemPedido.Quantidade
                }).ToList(),
            };

            return Ok(response);
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<List<PedidoResponse>>> GetPedidosPorCliente(int clienteId)
        {
            var cliente = await _clienteUse.BuscaPorId(clienteId);
            if (cliente is null)
                return BadRequest($"O cliente com o id {clienteId} não foi encontrado.");

            var pedido = await _pedidoUseCase.BuscaPorClienteId(clienteId);
            if (pedido == null)
                return NotFound($"Nenhum pedido encontrado para o cliente {clienteId}.");

            var response = new PedidoResponse
            {
                Id = pedido.Id,
                NomeCliente = pedido.Cliente.NomeCliente,
                Itens = pedido.Items.Select(itemPedido => new ItemPedidoResponse
                {
                    IdProduto = itemPedido.Produto.Id,
                    NomeProduto = itemPedido.Produto.Nome,
                    Quantidade = itemPedido.Quantidade,
                    ValorUnitario = itemPedido.Produto.ValorUnitario,
                    ValorTotal = itemPedido.Produto.ValorUnitario * itemPedido.Quantidade
                }).ToList(),
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PedidoRequest request)
        {                  
            var cliente = await _clienteUse.BuscaPorId(request.IdCliente);
            if (cliente is null)
                return BadRequest($"O cliente com o id {request.IdCliente} não foi encontrado.");

            foreach (var item in request.Itens)
            {
                var produto = await _produtoUseCase.BuscaPorId(item.IdProduto);
                if (produto is null)
                    return BadRequest($"O produto com o id {item.IdProduto} não foi encontrado.");
            }

            var pedido = new Pedido
            {
                ClienteId = request.IdCliente,
                Items = request.Itens.Select(itemPedido => new ItemPedido()
                {
                    ProdutoId = itemPedido.IdProduto,
                    Quantidade = itemPedido.Quantidade,
                }).ToList()
            };

            await _pedidoUseCase.CadastrarPedido(pedido);
            return NoContent();            
        }
    }

}
