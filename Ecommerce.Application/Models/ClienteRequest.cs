using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Models
{
    public class ClienteRequest
    {
        public string NomeCliente { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public DadosContatoRequest Contato { get; set; }
    }
}
