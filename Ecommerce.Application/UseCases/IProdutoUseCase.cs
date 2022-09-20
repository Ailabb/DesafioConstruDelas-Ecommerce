using Ecommerce.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases
{
    public interface IProdutoUseCase
    {
        public Task<List<Produto>> ListagemDeProdutos();
        public Task<Produto> BuscaPorId(int id);
        public Task CadastrarProduto(Produto produto);
    }
}
