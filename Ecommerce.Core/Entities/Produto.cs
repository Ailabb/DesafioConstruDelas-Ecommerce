using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Core.Entities
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public double ValorUnitario { get; set; }
    }
}
