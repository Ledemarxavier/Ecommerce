using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    public class Carrinho : Entidade
    {
        public List<Produto> Produtos { get; set; }
    }
}
