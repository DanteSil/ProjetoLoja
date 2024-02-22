using Microsoft.AspNetCore.Mvc;
using ProjetoLoja.DTOs;

namespace ProjetoLoja.Controller
{
    public class ProductController : ControllerBase
    {
        [HttpPost("v1/products")]
        public IActionResult Create([FromBody]ProductDTO request)
        {
            return Ok($"Você quer salvar o produto: {request.Title}, do preço: {request.Price}, do tamanho {request.Size}");
        }

        [HttpGet("v1/products")]
        public IActionResult Get(ProductDTO request)
        {
            return Ok($"Você quer salvar o produto: {request.Title}, do preço: {request.Price}, do tamanho {request.Size}");
        }
    }
}
