using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Models
{
    public class ItemPedidoRequest
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
