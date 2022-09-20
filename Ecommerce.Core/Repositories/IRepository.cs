using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Repositories
{
    public interface IRepository
    {
        Task<List<Cliente>> ListagemDeClientes();
        Task<Cliente> ConsultaClienteId(int id);
        Task CadastrarCliente(Cliente cliente);
        Task CadastrarPedido(Pedido pedido);
        Task CadastrarProduto(Produto produto);

    }
}
