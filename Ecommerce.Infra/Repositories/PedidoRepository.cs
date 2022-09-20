using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories;
using Ecommerce.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            return await _context.Pedido
                .AsNoTracking()
                .Include(x => x.Cliente)
                .Include(x => x.Items)
                    .ThenInclude(x => x.Produto)
                .ToListAsync();
        }

        public async Task<Pedido> BuscaPorId(int id)
        {            
            return await _context.Pedido
                .AsNoTracking()
                .Where(pedido => pedido.Id == id)
                .Include(x => x.Cliente)
                .Include(x => x.Items)                
                    .ThenInclude(x => x.Produto)
                .FirstOrDefaultAsync();
        }

        public async Task<Pedido> BuscaPorClienteId(int clienteId)
        {
            return await _context.Pedido
                .AsNoTracking()
                .Where(pedido => pedido.ClienteId == clienteId)
                .Include(x => x.Cliente)
                .Include(x => x.Items)
                    .ThenInclude(x => x.Produto)
                .FirstOrDefaultAsync();
        }

        public Task CadastrarPedido(Pedido pedido)
        {
            _context.Add(pedido);
            _context.SaveChanges();
            return Task.FromResult(pedido);
        }

    }
}
