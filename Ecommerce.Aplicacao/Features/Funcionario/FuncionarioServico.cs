using Ecommerce.Domain;
using Ecommerce.Infra.Data;
using Ecommerce.Infra.Data.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Aplicacao.Features
{
    public class FuncionarioServico
    {
        public FuncionarioRepositorio funcionarioRepositorio;

        public FuncionarioServico(EcommerceDbContext ecommerceDbContext)
        {
            funcionarioRepositorio = new FuncionarioRepositorio(ecommerceDbContext);
        }

        public List<Funcionario> SelecionarFuncionarios()
        {
            return funcionarioRepositorio.SelecionarFuncionarios();
        }

        public Funcionario SelecionarFuncionario(string nome)
        {
            var funcionarioEncontrado = funcionarioRepositorio.SelecionarFuncionario(nome);

            //var funcionarioNaoFoiEncontrado = funcionarioEncontrado is null;

            //if (funcionarioNaoFoiEncontrado)
            //    return NotFound();

            return funcionarioEncontrado;
        }

        public void CriarFuncionario(Funcionario funcionario)
        {
            funcionarioRepositorio.CriarFuncionario(funcionario);
        }

        public Funcionario AtualizarFuncionario(Funcionario funcionarioAtualizado)
        {
            var funcionarioEncontradoAntesDaAtualizacao = funcionarioRepositorio.SelecionarFuncionario(funcionarioAtualizado.Nome);

            if(funcionarioEncontradoAntesDaAtualizacao is null)
            {
                return null;
            }

            funcionarioEncontradoAntesDaAtualizacao.Senha = funcionarioAtualizado.Senha;
            funcionarioEncontradoAntesDaAtualizacao.Email = funcionarioAtualizado.Email;
            funcionarioEncontradoAntesDaAtualizacao.Nivel = funcionarioAtualizado.Nivel;
            funcionarioEncontradoAntesDaAtualizacao.Cargo = funcionarioAtualizado.Cargo;

            funcionarioRepositorio.Salva();

            return funcionarioRepositorio.SelecionarFuncionario(funcionarioAtualizado.Nome);

        }
    }
}
