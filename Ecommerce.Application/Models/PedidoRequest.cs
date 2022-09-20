using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Models
{
    public class PedidoRequest
    {
        public int IdCliente { get; set; }
        public List<ItemPedidoRequest> Itens { get; set; }
    }
}
