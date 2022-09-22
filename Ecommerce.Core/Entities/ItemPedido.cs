using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class ItemPedido
    {

        //1 ItemPedido representa 1 linha em uma nota
        [Key]//Indicando que o ID é uma chave primaria 
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto  { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int Quantidade { get; set; }
    }
}
