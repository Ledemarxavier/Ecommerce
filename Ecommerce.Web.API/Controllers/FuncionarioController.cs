using Ecommerce.Domain;
using Ecommerce.Infra.Data;
using Ecommerce.Infra.Data.Features;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace Ecommerce.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        FuncionarioRepository funcionarioRepository;

        public FuncionarioController()
        {
            EcommerceDbContext ecommerceDbContext = new EcommerceDbContext();
            funcionarioRepository = new FuncionarioRepository(ecommerceDbContext);
        }

        [HttpGet]
        public List<Funcionario> GetFuncionarios()
        {
            return funcionarioRepository.ListarFuncionarios();
        }

        //[HttpGet("{nome}")]
        //public IActionResult GetFuncionario(string nome)
        //{
        //    var funcionarioEncontrado = ecommerceDbContext.Funcionarios.First(funcionario => funcionario.Nome == nome);

        //    var funcionarioNaoFoiEncontrado = funcionarioEncontrado is null;

        //    if (funcionarioNaoFoiEncontrado)
        //        return NotFound();

        //    return Ok(funcionarioEncontrado);
        //}

        //[HttpPost]
        //public void CreateFuncionario([FromBody] Funcionario funcionario)
        //{
        //    ecommerceDbContext.Funcionarios.Add(funcionario);
        //    ecommerceDbContext.SaveChanges();

        //}

        //[HttpPut()]
        //public IActionResult UpdateFuncionario([FromBody] Funcionario funcionarioAtualizado)
        //{
        //    var funcionarioEncontradoNoBanco = ecommerceDbContext.Funcionarios.First(funcionario => funcionario.Nome == funcionarioAtualizado.Nome);

        //    var funcionarioNaoFoiEncontrado = funcionarioEncontradoNoBanco is null;

        //    if (funcionarioNaoFoiEncontrado)
        //        return NotFound();

        //    funcionarioEncontradoNoBanco.Nome = funcionarioAtualizado.Nome;
        //    funcionarioEncontradoNoBanco.Senha = funcionarioAtualizado.Senha;
        //    funcionarioEncontradoNoBanco.Email = funcionarioAtualizado.Email;
        //    funcionarioEncontradoNoBanco.Nivel = funcionarioAtualizado.Nivel;
        //    funcionarioEncontradoNoBanco.Cargo = funcionarioAtualizado.Cargo;
        //    ecommerceDbContext.SaveChanges();

        //    return Ok(ecommerceDbContext.Funcionarios.First(funcionario => funcionario.Nome == funcionarioAtualizado.Nome));
            
        //}

        //[HttpDelete()]
        //public IActionResult DeleteFuncionario([FromBody] Funcionario funcionarioParaDeletar)
        //{
        //    var funcionarioEncontrado = ecommerceDbContext.Funcionarios.First(funcionario => funcionario.Nome == funcionarioParaDeletar.Nome);

        //    var funcionarioNaoFoiEncontrado = funcionarioEncontrado is null;

        //    if (funcionarioNaoFoiEncontrado)
        //        return NotFound();

        //    ecommerceDbContext.Funcionarios.Remove(funcionarioEncontrado);
        //    ecommerceDbContext.SaveChanges();

        //    return Ok(ecommerceDbContext.Funcionarios);
        //}

    }
}