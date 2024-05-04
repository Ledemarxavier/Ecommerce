//using Ecommerce.Domain;
//using Ecommerce.Infra.Data;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http.Headers;

//namespace Ecommerce.Web.API.Controllers
//{

//    [Route("api/[controller]")]
//    [ApiController]
//    public class CompraRealizadaController : ControllerBase
//    {
//        EcommerceDbContext ecommerceDbContext;

//        public CompraRealizadaController()
//        {
//            ecommerceDbContext = new EcommerceDbContext();
//        }
        
//        [HttpGet]
//        public List<CompraRealizada> GetComprasRealizadas()
//        {
//            return ecommerceDbContext.ComprasRealizadas.ToList();
//        }

//        [HttpPost]
//        public void CreateCompraRealizada([FromBody] CompraRealizada comprarealizada)
//        {
//            ecommerceDbContext.ComprasRealizadas.Add(comprarealizada);
//            ecommerceDbContext.SaveChanges();
//        }

//        [HttpPut()]
//        public IActionResult UpdateCompraRealizada([FromBody] CompraRealizada compraRealizadaAtualizada)
//        {
//            var comprarealizadaEncontradoNoBanco = ecommerceDbContext.ComprasRealizadas.First(comprarealizada => comprarealizada.Id == compraRealizadaAtualizada.Id);

//            var comprarealizadaNaoFoiEncontrado = comprarealizadaEncontradoNoBanco is null;

//            if (comprarealizadaNaoFoiEncontrado)
//                return NotFound();

//            comprarealizadaEncontradoNoBanco.Cliente = compraRealizadaAtualizada.Cliente;
//            comprarealizadaEncontradoNoBanco.Data = compraRealizadaAtualizada.Data;
//            comprarealizadaEncontradoNoBanco.Produto = compraRealizadaAtualizada.Produto;

//            ecommerceDbContext.SaveChanges();

//            return Ok(ecommerceDbContext.ComprasRealizadas.First(comprarealizada => comprarealizada.Cliente == compraRealizadaAtualizada.Cliente));
//        }

//        [HttpDelete()]
//        public IActionResult DeleteCompraRealizada([FromBody] CompraRealizada comprarealizadaParaDeletar)
//        {
//            var comprarealizadaEncontrada = ecommerceDbContext.ComprasRealizadas.First(comprarealizada => comprarealizada.Cliente == comprarealizadaParaDeletar.Cliente);

//            var comprarealizadaNaoFoiEncontrada = comprarealizadaEncontrada is null;

//            if (comprarealizadaNaoFoiEncontrada)
//                return NotFound();

//            ecommerceDbContext.ComprasRealizadas.Remove(comprarealizadaEncontrada);
//            ecommerceDbContext.SaveChanges();

//            return Ok(ecommerceDbContext.ComprasRealizadas);
//        }
//    }
//}

