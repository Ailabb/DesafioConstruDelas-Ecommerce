using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Models
{
    public class ProdutoResponse
    {
        public int IdProduto { get; set; }
        public string NomedoProduto { get; set; }
        public int QuantdProduto { get; set; }
        public double ValorDoProduto { get; set; }
    }
}
