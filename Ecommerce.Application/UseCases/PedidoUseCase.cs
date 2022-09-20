using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases
{
    public class PedidoUseCase : IPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public async Task<List<Pedido>> ListagemDePedidos()
        {
            return await _pedidoRepository.ListagemDePedidos();
        }

        public async Task<Pedido> BuscaPorId(int id)
        {
            return await _pedidoRepository.BuscaPorId(id);
        }

        public Task CadastrarPedido(Pedido pedido)
        {
            return _pedidoRepository.CadastrarPedido(pedido);
        }
    }

}
