using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases
{
    public class ProdutoUseCase : IProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<List<Produto>> ListagemDeProdutos()
        {
            return await _produtoRepository.ListagemDeProdutos();
        }

        public async Task<Produto> BuscaPorId(int id)
        {
            return await _produtoRepository.BuscaPorId(id);
        }

        public Task CadastrarProduto(Produto produto)
        {
            return _produtoRepository.CadastrarProduto(produto);
        }
    }
}
