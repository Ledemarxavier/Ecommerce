using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    public class Funcionario : Usuario
    {
       
        public Nivel Nivel { get; set; }
        public Cargo Cargo { get; set; }


     
    }
}
