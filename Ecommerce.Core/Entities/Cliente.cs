using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Core.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get;  set; }
        public string NomeCliente { get;  set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get;  set; }
        public DadosContatoCliente Contato { get; set; }

    }

    
}
