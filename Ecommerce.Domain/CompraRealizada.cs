using System;
using System.Collections.Generic;

namespace Ecommerce.Domain
{
    public class CompraRealizada : Entidade
    {
        public List<Produto> Produtos { get; set; }
        public DateTime Data { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }

    }
}
