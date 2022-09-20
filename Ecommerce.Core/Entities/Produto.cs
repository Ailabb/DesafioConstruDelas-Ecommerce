using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Core.Entities
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public string NomedoProduto { get; set; }
        public double ValorUnitarioProduto { get; set; }
    }
}
