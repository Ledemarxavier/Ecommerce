using Ecommerce.Domain;
using Ecommerce.Infra.Data;
using Ecommerce.Infra.Data.Features;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;


namespace Ecommerce.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        public FuncionarioRepositorio FuncionarioRepositorio { get; set; }


        public FuncionarioController()
        {
            EcommerceDbContext ecommerceDbContext=new EcommerceDbContext();
            FuncionarioRepositorio = new FuncionarioRepositorio(ecommerceDbContext);
        }

        [HttpGet]
        public List<Funcionario> GetFuncionario()
        {
            return FuncionarioRepositorio.ListarFuncionarios();
        }

        [HttpGet("{nome}")]
        public IActionResult GetFuncionario(string nome)
        {
            var funcionarioEncontrado = FuncionarioRepositorio.ListarFuncionario(nome);

            var funcionarioNaoFoiEncontrado = funcionarioEncontrado is null;

            if (funcionarioNaoFoiEncontrado)
                return NotFound();

            return Ok(funcionarioEncontrado);
        }

        [HttpPost]
        public void CreateFuncionario([FromBody] Funcionario funcionario)
        {
            FuncionarioRepositorio.CriarFuncionario(funcionario);

        }

        [HttpPut()]
        public IActionResult UpdateFuncionario([FromBody] Funcionario funcionarioAtualizado)
        {
            var funcionarioEncontradoNoBanco = FuncionarioRepositorio.ListarFuncionario(funcionarioAtualizado.Nome);

            var funcionarioNaoFoiEncontrado = funcionarioEncontradoNoBanco is null;

            if (funcionarioNaoFoiEncontrado)
                return NotFound();

            funcionarioEncontradoNoBanco.Nome = funcionarioAtualizado.Nome;
            funcionarioEncontradoNoBanco.Senha = funcionarioAtualizado.Senha;
            funcionarioEncontradoNoBanco.Email = funcionarioAtualizado.Email;
            funcionarioEncontradoNoBanco.Nivel = funcionarioAtualizado.Nivel;
            funcionarioEncontradoNoBanco.Cargo = funcionarioAtualizado.Cargo;

            FuncionarioRepositorio.Salva();

            return Ok(FuncionarioRepositorio.ListarFuncionario(funcionarioAtualizado.Nome));

        }

        [HttpDelete()]
        public IActionResult DeleteFuncionario([FromBody] Funcionario funcionarioParaDeletar)
        {
            var funcionarioEncontrado = FuncionarioRepositorio.ListarFuncionario(funcionarioParaDeletar.Nome);

            var funcionarioNaoFoiEncontrado = funcionarioEncontrado is null;

            if (funcionarioNaoFoiEncontrado)
                return NotFound();
            FuncionarioRepositorio.Remover(funcionarioEncontrado);
           

            return Ok(FuncionarioRepositorio.ListarFuncionarios());
        }

    }
}