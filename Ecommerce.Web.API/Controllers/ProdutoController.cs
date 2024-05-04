using Ecommerce.Domain;
using Ecommerce.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Ecommerce.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        EcommerceDbContext ecommerceDbContext;
        public ProdutoController()
        {
            ecommerceDbContext = new EcommerceDbContext();
        }

        [HttpGet]
        public List<Produto> GetProduto()
        {
            return ecommerceDbContext.Produtos.ToList();
        }

        [HttpGet("{codigo}")]
        public IActionResult GetProduto(string codigo)
        {
            var produtoEncontrado = ecommerceDbContext.Produtos.First(produto => produto.Nome == codigo);

            var produtoNaoFoiEncontrado = produtoEncontrado is null;

            if (produtoNaoFoiEncontrado)
                return NotFound();

            return Ok(produtoEncontrado);
        }

        [HttpGet("{nome}")]
        public IActionResult GetProducto(string nome)
        {
            var produtoEncontrado = ecommerceDbContext.Produtos.First(produto => produto.Nome == nome);

            var produtoNaoFoiEncontrado = produtoEncontrado is null;

            if (produtoNaoFoiEncontrado)
                return NotFound();

            return Ok(produtoEncontrado);
        }

        [HttpPost]
        public void CreateProduto([FromBody] Produto produto)
        {
            ecommerceDbContext.Produtos.Add(produto);
            ecommerceDbContext.SaveChanges();
        }

        [HttpPut("{codigo}")]

        public IActionResult UpdateProduto([FromBody] Produto produtoAtualizado)
        {
            var produtoEncontradoNoBanco = ecommerceDbContext.Produtos.First(produto => produto.Codigo == produtoAtualizado.Codigo);

            var produtoNaoFoiEncontrado = produtoEncontradoNoBanco is null;

            if (produtoNaoFoiEncontrado)
                return NotFound();

            produtoEncontradoNoBanco.Nome = produtoAtualizado.Nome;
            produtoEncontradoNoBanco.Codigo = produtoAtualizado.Codigo;
            produtoEncontradoNoBanco.Preco = produtoAtualizado.Preco;

            ecommerceDbContext.SaveChanges();

            return Ok(ecommerceDbContext.Produtos.First(produto => produto.Codigo == produtoAtualizado.Codigo));

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto([FromBody] Produto produtoParaDeletar)
        {
            var produtoEncontrado = ecommerceDbContext.Produtos.First(produto => produto.Codigo == produtoParaDeletar.Codigo);

            var produtoNaoFoiEncontrado = produtoEncontrado is null;

            if (produtoNaoFoiEncontrado)
                return NotFound();

            ecommerceDbContext.Produtos.Remove(produtoEncontrado);
            ecommerceDbContext.SaveChanges();

            return Ok(ecommerceDbContext.Produtos);
        }
    }
}

