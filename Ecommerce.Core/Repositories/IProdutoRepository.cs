using Ecommerce.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Core.Repositories
{
    public interface IProdutoRepository
    {
        public Task<List<Produto>> ListagemDeProdutos();
        public Task<Produto> BuscaPorId(int id);
        public Task CadastrarProduto(Produto produto);

    }
}
