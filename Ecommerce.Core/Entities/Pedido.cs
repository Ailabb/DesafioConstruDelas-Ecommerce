using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Core.Entities
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }        
        public Cliente Cliente { get; set; }        
        public List<ItemPedido> Itens { get; set; }// aqui guarda os itens do pedido e suas respectivas quantidades.
    }
}
