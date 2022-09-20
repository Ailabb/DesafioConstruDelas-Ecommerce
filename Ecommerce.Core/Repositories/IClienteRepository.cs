using Ecommerce.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Core.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> ListagemDeClientes();
        Task<Cliente> BuscaPorId(int id);
        Task CadastrarCliente(Cliente cliente);
    }
}
