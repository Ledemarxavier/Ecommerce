using Ecommerce.Aplicacao.Features;
using Ecommerce.Domain;
using Ecommerce.Infra.Data;
using Ecommerce.Infra.Data.Features;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Ecommerce.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        public FuncionarioServico funcionarioServico;

        public FuncionarioController()
        {
            EcommerceDbContext ecommerceDbContext = new EcommerceDbContext();

            funcionarioServico = new FuncionarioServico(ecommerceDbContext);
        }

        [HttpGet]
        public List<Funcionario> GetFuncionarios()
        {
            return funcionarioServico.SelecionarFuncionarios();
        }

        [HttpGet("{nome}")]
        public IActionResult GetFuncionario(string nome)
        {
            var funcionarioEncontrado = funcionarioServico.SelecionarFuncionario(nome);

            var funcionarioNaoFoiEncontrado = funcionarioEncontrado is null;

            if (funcionarioNaoFoiEncontrado)
                return NotFound();

            return Ok(funcionarioEncontrado);
        }

        [HttpPost]
        public void CreateFuncionario([FromBody] Funcionario funcionario)
        {
            funcionarioServico.CriarFuncionario(funcionario);
        }

        [HttpPut()]
        public IActionResult UpdateFuncionario([FromBody] Funcionario funcionarioAtualizado)
        {
            Funcionario funcionarioAtualizadoDoBanco = funcionarioServico.AtualizarFuncionario(funcionarioAtualizado);

            return Ok(funcionarioAtualizadoDoBanco);
        }

        //[HttpDelete()]
        //public IActionResult DeleteFuncionario([FromBody] Funcionario funcionarioParaDeletar)
        //{
        //    var funcionarioEncontrado = FuncionarioRepositorio.ListarFuncionario(funcionarioParaDeletar.Nome);

        //    var funcionarioNaoFoiEncontrado = funcionarioEncontrado is null;

        //    if (funcionarioNaoFoiEncontrado)
        //        return NotFound();
        //    FuncionarioRepositorio.Remover(funcionarioEncontrado);


        //    return Ok(FuncionarioRepositorio.SelecionarFuncionarios());
        //}

    }
}