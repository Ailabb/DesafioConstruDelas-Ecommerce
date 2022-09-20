using Ecommerce.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases
{
    public interface IPedidoUseCase
    {
        public Task<List<Pedido>> ListagemDePedidos();
        public Task<Pedido> BuscaPorId(int id);
        public Task CadastrarPedido(Pedido pedido);
    }
}
