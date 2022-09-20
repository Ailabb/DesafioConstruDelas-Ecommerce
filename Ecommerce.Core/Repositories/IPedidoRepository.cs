using Ecommerce.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Core.Repositories
{
    public interface IPedidoRepository
    {
        public Task<List<Pedido>> ListagemDePedidos();
        public Task<Pedido> BuscaPorId(int id);
        public Task<Pedido> BuscaPorClienteId(int clienteId);
        public Task CadastrarPedido(Pedido pedido);
    }
}
