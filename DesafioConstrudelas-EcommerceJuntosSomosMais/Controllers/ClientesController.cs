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
    [Route("api/clientes")]
   

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
        public async Task<ActionResult<List<ClienteResponse>>> Get()
        {
            var response = await _clienteUse.ListagemDeClientes();
            if (response == null)
                return NotFound();

            return Ok(response);
        }
        [HttpGet("{id}")]
        //Endpoint api/clientes/id
        //Endpoint para Buscar Cliente por Id
        public async Task<ActionResult<ClienteResponse>> GetPorId(int id)
        {
            var response = await _clienteUse.BuscaPorId(id);

            if (response == null)
                return NotFound("Cliente não encontrado");

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(ClienteRequest request)
        {
            //Seria interessante saber se esse cliente já foi cadastrado
            var cliente = new Cliente
            {
                NomeCliente = request.NomeCliente,
                DataNascimento = request.DataNascimento,
                Contato = new DadosContatoCliente
                {
                    Celular = request.Contato.Celular,
                    TelefoneResidencial = request.Contato.TelefoneResidencial,
                    Email = request.Contato.Email,
                }
            };

            await _clienteUse.CadastrarCliente(cliente);
            return NoContent();//sem devolução
        }
                
    }
}
