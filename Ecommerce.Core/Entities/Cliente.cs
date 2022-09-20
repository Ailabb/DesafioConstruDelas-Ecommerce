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
        public int Id { get;  set; }
        public string NomeCliente { get;  set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get;  set; }


    }
}
