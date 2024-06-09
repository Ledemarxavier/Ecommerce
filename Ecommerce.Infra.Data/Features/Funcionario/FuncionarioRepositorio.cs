using Ecommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Data.Features
{
    public class FuncionarioRepositorio
    {
        public EcommerceDbContext ecommerceDbContext { get; set; }

        public FuncionarioRepositorio(EcommerceDbContext ecommerceDbContext)
        {
            this.ecommerceDbContext = ecommerceDbContext;
        }
        public List<Funcionario> ListarFuncionarios()
        {
            return ecommerceDbContext.Funcionarios.ToList();
        }

        public Funcionario ListarFuncionario(string nomeBusca)
        {
        return ecommerceDbContext.Funcionarios.First(f=>f.Nome== nomeBusca);
        }

        public void CriarFuncionario(Funcionario funcionario)
        {
            ecommerceDbContext.Funcionarios.Add(funcionario);
            Salva();
        }
        public void Salva()
        {
            ecommerceDbContext.SaveChanges();
        }
        public void Remover(Funcionario funcionarioParaDeletar) 
        {
            ecommerceDbContext.Funcionarios.Remove(funcionarioParaDeletar);
            ecommerceDbContext.SaveChanges();
        }
    }
}
