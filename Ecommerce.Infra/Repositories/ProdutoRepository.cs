using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories;
using Ecommerce.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationContext _context;

        public ProdutoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> ListagemDeProdutos()
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task<Produto> BuscaPorId(int id)
        {
            //para filtrar usei o Linq
            return await _context.Produto.FirstOrDefaultAsync(produto => produto.Id == id);
        }

        public Task CadastrarProduto(Produto produto)
        {
            _context.Produto.Add(produto);
            _context.SaveChanges();
            return Task.FromResult(produto);
        }

    }
}
