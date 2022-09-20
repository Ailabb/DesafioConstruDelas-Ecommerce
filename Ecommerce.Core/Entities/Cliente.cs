using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get;  set; }
        public string NomeDoCliente { get;  set; }
        public DateTime DataNascimento { get;  set; }


    }
}
