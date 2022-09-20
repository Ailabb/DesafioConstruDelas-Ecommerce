using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases
{
    /// <summary>
    /// Ligação entre Controller e Repository. Scopo único para cliente
    /// </summary>
    public class ClienteUseCase : IClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<List<Cliente>> ListagemDeClientes()
        {
            return await _clienteRepository.ListagemDeClientes();
        }

        public async Task<Cliente> BuscaPorId(int id)
        {
            return await _clienteRepository.BuscaPorId(id);
        }

        public Task CadastrarCliente(Cliente cliente)
        {
            return _clienteRepository.CadastrarCliente(cliente);
        }
    }
}
