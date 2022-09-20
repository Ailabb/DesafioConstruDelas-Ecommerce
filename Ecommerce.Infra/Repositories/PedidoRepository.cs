using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories;
using Ecommerce.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationContext _context;

        public PedidoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> ListagemDePedidos()
        {
            return await _context.Pedido.ToListAsync();
        }

        public async Task<Pedido> BuscaPorId(int id)
        {
            return await _context.Pedido.FirstOrDefaultAsync(pedido => pedido.IdPedido == id);
        }

        public Task CadastrarPedido(Pedido pedido)
        {
            _context.Add(pedido);
            _context.SaveChanges();
            return Task.FromResult(pedido);
        }

    }
}
