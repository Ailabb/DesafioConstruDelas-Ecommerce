using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories;
using Ecommerce.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationContext _context;

        public ClienteRepository(ApplicationContext context)
        {
            _context = context;
        }
        //Ligação com banco
        public async Task<List<Cliente>> ListagemDeClientes()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente> BuscaPorId(int id)
        {
            //procurar o meu cliente e retornar caso  o encontre
            //para filtrar usei o Linq
            return await _context.Cliente.FirstOrDefaultAsync(cliente => cliente.Id == id);
        }

        public Task CadastrarCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
            return Task.FromResult(cliente);
        }
    }
}
