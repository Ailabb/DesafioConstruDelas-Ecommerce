using Ecommerce.Application.UseCases;
using Ecommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioConstrudelas_EcommerceJuntosSomosMais.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    //get para todos os usuarios
    //get para usuarios atraves do nome
    //get para usuarios atraves do id

    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IClienteUseCase _clienteUse;

        public ClientesController(ILogger<ClientesController> logger,
            IClienteUseCase clienteUse)
        {
            _logger = logger;
            _clienteUse = clienteUse;
        }

        [HttpGet]
        //Endpoint para Listagem de todos os clientes
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            var response = await _clienteUse.ListagemDeClientes();
            if (response == null)
                return NotFound();

            return Ok(response);
        }
        [HttpGet("{id}")]
        //Endpoint api/clientes/id
        //Endpoint para Buscar Cliente por Id
        public async Task<ActionResult<Cliente>> GetPorId(int id)
        {
            var response = await _clienteUse.BuscaPorId(id);

            if (response == null)
                return NotFound("Cliente não encontrado");

            return Ok(response);
        }

        [HttpPost("Cadastrar_Cliente")]
        public async Task<ActionResult> Insert(Cliente cliente)
        {
            await _clienteUse.CadastrarCliente(cliente);
            return NoContent();
        }

        //[HttpGet("Busca_por_nome")]
        //public async Task<ActionResult<ClienteResponse>> ConsultaClienteNome(string nomeDoCliente)
        //{
        //    var cliente = clientes.FirstOrDefault(nome => nome.NomeDoCliente == nomeDoCliente);
        //    if (cliente == null)
        //        return NotFound("Cliente não encontrado");

        //    return Ok(cliente);
        //}

    }
}
