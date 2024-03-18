using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoLoja.BaseUtils;
using ProjetoLoja.DataBase.MyDbContext;
using ProjetoLoja.DTOs.RequestDTOs;
using ProjetoLoja.Models;

namespace ProjetoLoja.Controller
{
    public class ProductController : ControllerBase
    {
        [HttpPost("v1/products")]
        public async Task<IActionResult> Create([FromBody]ProductRequestDTOs request, [FromServices]MyDbContext context)
        {
            try
            {
                if(request.Title == null) 
                    throw new Exception("Você esqueceu de informar o tiulo.");                
                
                if(request.Description == null) 
                    throw new Exception("Você esqueceu de informar a descrição.");

                if (request.Price == 0)
                    throw new Exception("Você esqueceu de informar o preço.");

                if (request.Color == null)
                    throw new Exception("Você esqueceu de informar a a cor.");

                if (request.Size == null)
                    throw new Exception("Você esqueceu de informar o tamanho.");


                var product = new Product()
                {
                    Title = request.Title,
                    Color = request.Color,
                    Description = request.Description,
                    Price = request.Price,
                    Size = request.Size,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };

                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();

                return Ok(new BaseResponse(true, null));
            }
            catch (Exception e) 
            {
                return StatusCode(500, new BaseResponse(false, e));
            }
        }

        [HttpGet("v1/products")]
        public async Task<IActionResult> Get([FromServices]MyDbContext context)
        {
            try
            {
                var produtcs = await context.Products.
                                                    Select(p => new {p.Pk_Id, p.Title, p.Price}).
                                                    ToListAsync();

                return Ok(new BaseResponse(true, produtcs));
            }
            catch (Exception ex) 
            {
                return StatusCode(500, new BaseResponse(false, ex));
            }
        }

        [HttpGet("v1/products/{id}")]
        public async Task<IActionResult> GetById([FromServices] MyDbContext context, int id)
        {
            try
            {
                var produtc = await context.Products.FirstOrDefaultAsync(x => x.Pk_Id == id);

                return Ok(new BaseResponse(true, produtc));
            }
            catch (Exception error)
            {
                return StatusCode(500, new BaseResponse(false, error));
            }
        }        
        
        [HttpPatch("v1/products/{id}")]
        public async Task<IActionResult> UpdateById([FromServices] MyDbContext context, int id, [FromBody]ProductRequestDTOs request)
        {
            try
            {
                var produtc = await context.Products.FirstOrDefaultAsync(x => x.Pk_Id == id);

                produtc.Title = request.Title ?? produtc.Title;
                produtc.Description = request.Description ?? produtc.Description;
                produtc.Color = request.Color ?? produtc.Color;
                produtc.Price = request.Price != 0 ? request.Price : produtc.Price;
                produtc.Size = request.Size ?? produtc.Size;
                produtc.UpdatedAt = DateTime.Now;

                await context.SaveChangesAsync();

                return Ok(new BaseResponse(true, produtc));
            }
            catch (Exception error)
            {
                return StatusCode(500, new BaseResponse(false, error));
            }
        }
    }
}
