using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories;
using Ecommerce.Infra.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Repositories
{
    public class EcommerceRepository : IRepository
    {
        private readonly ApplicationContext _context;

        public EcommerceRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task CadastrarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task CadastrarPedido(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Task CadastrarProduto(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> ConsultaClienteId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> ListagemDeClientes()
        {
            return Task.FromResult(_context.Set<Cliente>().ToList());
        }
    }
}
