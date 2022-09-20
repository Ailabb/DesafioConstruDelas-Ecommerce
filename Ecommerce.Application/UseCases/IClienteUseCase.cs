using Ecommerce.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases
{
    public interface IClienteUseCase
    {
        Task<List<Cliente>> ListagemDeClientes();
        Task<Cliente> BuscaPorId(int id);
        Task CadastrarCliente(Cliente cliente);
    }
}
