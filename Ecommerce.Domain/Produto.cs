using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain

{
    public class Produto : Entidade
    {
        public int Codigo { get; set; }
        public double Preco { get; set; }
        public string Nome { get; set; }

        
        
    }
}
