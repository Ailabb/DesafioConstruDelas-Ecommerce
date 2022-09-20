using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Models
{
    public class PedidoResponse
    {
        public int IdPedido { get; set; }
        public int QuantdItens { get; set; }
        public ClienteResponse Cliente { get; set; }
        public List<ProdutoResponse> Produtos { get; set; }
    }
}
