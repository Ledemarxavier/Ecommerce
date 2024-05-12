using Ecommerce.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Infra.Data.Features
{
    public class FuncionarioRepository
    {
        public EcommerceDbContext ecommerceDbContext { get; set; }

        public FuncionarioRepository(EcommerceDbContext ecommerceDbContext)
        {
            this.ecommerceDbContext = ecommerceDbContext;
        }

        public List<Funcionario> ListarFuncionarios()
        {
            return ecommerceDbContext.Funcionarios.ToList();
        } 

    }
}
