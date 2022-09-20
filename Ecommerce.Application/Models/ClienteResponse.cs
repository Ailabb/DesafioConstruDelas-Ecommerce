using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Models
{
    public class ClienteResponse
    {
        public int IdCliente { get; set; }
        public string NomeDoCliente { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
