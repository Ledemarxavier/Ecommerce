using Ecommerce.Domain;
using Ecommerce.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Web.API.Controllers
{

    [Route("api/[controller]")]

    [ApiController]

    public class ClienteController : ControllerBase
    {
        EcommerceDbContext ecommerceDbContext;

        public ClienteController()
        {
            ecommerceDbContext = new EcommerceDbContext();
        }

        [HttpGet]
        public List<Cliente> GetClientes()
        {
            return ecommerceDbContext.Clientes.ToList();

        }
        [HttpGet("{nome}")]
        public IActionResult GetCliente(string nome)
        {
            var clienteEncontrado = ecommerceDbContext.Clientes.First(cliente => cliente.Nome == nome);

            var clienteNaoFoiEncontrado = clienteEncontrado is null;

            if (clienteNaoFoiEncontrado)
                return NotFound();

            return Ok(clienteEncontrado);
        }

        [HttpPost]
        public void CreateCliente([FromBody] Cliente cliente)
        {
            ecommerceDbContext.Clientes.Add(cliente);
            ecommerceDbContext.SaveChanges();
        }

        [HttpPut()]
        public IActionResult UpdateCliente([FromBody] Cliente clienteAtualizado)
        {
            var clienteEncontradoNoBanco = ecommerceDbContext.Clientes.First(cliente => cliente.Nome == clienteAtualizado.Nome);

            var clienteNaoFoiEncontrado = clienteEncontradoNoBanco is null;

            if (clienteNaoFoiEncontrado)
                return NotFound();

            clienteEncontradoNoBanco.Nome = clienteAtualizado.Nome;
            clienteEncontradoNoBanco.Senha = clienteAtualizado.Senha;
            clienteEncontradoNoBanco.Email = clienteAtualizado.Email;

            ecommerceDbContext.SaveChanges();

            return Ok(ecommerceDbContext.Clientes.First(cliente => cliente.Nome == clienteAtualizado.Nome));

        }

        [HttpDelete()]
        public IActionResult DeleteCliente([FromBody] Cliente clienteParaDeletar)
        {
            var clienteEncontrado = ecommerceDbContext.Clientes.First(cliente => cliente.Nome == clienteParaDeletar.Nome);

            var clienteNaoFoiEncontrado = clienteEncontrado is null;

            if (clienteNaoFoiEncontrado)
                return NotFound();

            ecommerceDbContext.Clientes.Remove(clienteEncontrado);
            ecommerceDbContext.SaveChanges();

            return Ok(ecommerceDbContext.Clientes);
        }




    }
}






