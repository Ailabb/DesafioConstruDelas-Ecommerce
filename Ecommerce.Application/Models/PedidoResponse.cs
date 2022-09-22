using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Models
{
    public class PedidoResponse
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public List<ItemPedidoResponse> Itens { get; set; }
    }

    public class ItemPedidoResponse
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal { get; set; }
    }
}
