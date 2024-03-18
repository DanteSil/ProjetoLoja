using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoLoja.BaseUtils;
using ProjetoLoja.DataBase.MyDbContext;
using ProjetoLoja.DTOs.RequestDTOs;
using ProjetoLoja.Models;
using SecureIdentity.Password;

namespace ProjetoLoja.Controller
{
    public class UserController : ControllerBase
    {
        [HttpPost("v1/user")]
        public async Task<IActionResult> Create([FromServices]MyDbContext context, [FromBody]UserRequestDTO request)
        {
            try
            {
                if (request.FirstName == null || request.LastName == null) 
                    throw new Exception("Informe o nome completo para continuar.");
                
                if(request.Password == null) 
                    throw new Exception("Informe a senha que deseja salvar.");

                if(request.Password.Length < 6)
                    throw new Exception("A senha deve ter 6 caracteres no mínimo.");

                if(request.Email == null) 
                    throw new Exception("Informe um E-mail para continuar.");

                var user = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Image = request.Image
                };

                user.Pk_Id = new Guid();

                user.Password = PasswordHasher.Hash(request.Password);

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return Ok(new BaseResponse(true, null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BaseResponse(false, ex));
            }
        }
    }
}
