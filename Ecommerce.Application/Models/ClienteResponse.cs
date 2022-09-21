using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Models
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public List<DadosContatoResponse> Contato { get; set; }
    }

    public class DadosContatoResponse
    {
        public string Celular { get; set; }
        public string TelefoneResidencial { get; set; }
        public string Email { get; set; }
    }
}
